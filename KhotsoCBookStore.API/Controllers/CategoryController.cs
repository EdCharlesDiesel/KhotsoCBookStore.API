using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {        
        private readonly ICategoryService _categoryRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryRepository,
                                  IMailService mailService,
                                  IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(_mailService));
            _categoryRepository = categoryRepository?? throw new ArgumentNullException(nameof(_categoryRepository));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetCategoryAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        } 

        /// <summary>
        /// Create a category resource.
        /// </summary>
        /// <returns>Category resource created</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="201">Returns the created category.</response>        
        /// <response code="400">Returns an error if the category is in the wrong format.</response>
        [HttpPost(), DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryForCreateDto newCategory)
        {
            if (ModelState.IsValid)
            {
                var categoryToCreate = _mapper.Map<Entities.Category>(newCategory);
                await _categoryRepository.CreateCategoryAsync(categoryToCreate);
                await _categoryRepository.SaveChangesAsync();

                var categoryToReturn = _mapper.Map<Category>(categoryToCreate);

                return CreatedAtRoute("GetCategory",
                    new { categoryId = categoryToReturn.CategoryId },
                    categoryToReturn);
            }
            else
                return BadRequest(ModelState);                
        }    

        /// <summary>
        /// Get all category resources.
        /// </summary>
        /// <returns>Returns category</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategorys()
        { 
            var categorys = await _categoryRepository.GetAllCategoriesAync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categorys));          
        }

        /// <summary>
        /// Get a single category resource by categoryId.
        /// </summary>
        /// <returns>A single category</returns>
        /// <response code="200">Returns requested category resource by id.</response>
        /// <response code="404">Returns error if the requested category resource is not found.</response>
        [HttpGet("{categoryId}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid categoryId)
        {
            if (categoryId == new Guid())
            {
               return NotFound();
            }          

            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return Ok(_mapper.Map<CategoryDto>(category));
        }       

        /// <summary>
        /// Update a category resource by categoryId.
        /// </summary>
        /// <returns>Updated category resource</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPut("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdateCategory(Guid categoryId,[FromBody] CategoryForUpdateDto categoryToUpdate)
        {
            if (!await _categoryRepository.CategoryIfExistsAsync(categoryId))
            {
                return NotFound();
            }

            var categoryEntity =  await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryToUpdate, categoryEntity);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update category resource by categoryId.
        /// </summary>
        /// <returns>No content if category resource was updated successfully</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPatch("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> PartiallyUpdateCategory(Guid categoryId,
            JsonPatchDocument<CategoryForUpdateDto> patchDocument)
        {
            if (!await _categoryRepository.CategoryIfExistsAsync(categoryId))
            {
                return NotFound();
            }

            var categoryEntity =  _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            var categoryToPatch = _mapper.Map<CategoryForUpdateDto>(categoryEntity);

            //patchDocument.ApplyTo(categoryToPatch, ModelState);
            patchDocument.ApplyTo(categoryToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(categoryToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(categoryToPatch, categoryEntity);
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single category resource by categoryId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            if (!await _categoryRepository.CategoryIfExistsAsync(categoryId))
            {
                return NotFound();
            }

            var categoryEntity = await  _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

             _categoryRepository.DeleteCategory(categoryEntity);
            await _categoryRepository.SaveChangesAsync();

            var category = _mapper.Map<Category>(categoryEntity);

            _mailService.Send(
            "Category deleted.",
            $"Category named {category.CategoryName} with id {category.CategoryId} was deleted.");

            return NoContent();
        }        
    }
}

   