using System;
using Xunit;
using KhotsoCBookStore.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoMapper;
using KhotsoCBookStore.API.Services;
using KhotsoCBookStore.API.Profiles;
using System.Collections.Generic;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KhotsoCBookStore.API.Tests.ControllerTests
{
    public class CategoryControllerTests : IDisposable
    {
        Mock<ICategoryService> mockCategoryRepo;
        Mock<IMailService> mockMail;
        CategoryMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        Mock<IWebHostEnvironment> mockWeHost;
        Mock<IConfiguration> mockConfig;

         string coverImageFolderPath = string.Empty;

        public CategoryControllerTests()
        {
            mockCategoryRepo = new Mock<ICategoryService>();
            mockMail = new Mock<IMailService>();
            mockConfig = new Mock<IConfiguration>();
            mockWeHost = new Mock<IWebHostEnvironment>();
            realProfile = new CategoryMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
           
           ;
        }
        public void Dispose()
        {
            mockMail = null;
            mockCategoryRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }        

        private List<Category> GetCategorysTest(int num)
        {
            var book = new List<Category>();
            if (num > 0)
            {
                book.Add(new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "Rocket Science",
                    CreatedBy = "system"
                });
            }
            return  book;
        }

        [Fact]
        public async Task GetAllCategorys_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockCategoryRepo.Setup(repo =>
            repo.GetAllCategoriesAync())
            .ReturnsAsync(() => null);


            var controller = new CategoryController(mockCategoryRepo.Object,
                                                mockMail.Object,
                                                mockConfig.Object,
                                                mockWeHost.Object,
                                                mapper);

            //Act
            var result = await controller.GetCategorys();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }        

        [Fact]
        public async Task  GetAllCategorys_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            mockCategoryRepo.Setup(repo =>
            repo.GetAllCategoriesAync()).ReturnsAsync(GetCategorysTest(1));
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act            
            var result = await controller.GetCategorys();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var book = okResult.Value as List<CategoryDto>;
            Assert.Single(book);
        }

        [Fact]
        public async Task GetAllCategorys_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockCategoryRepo.Setup(repo =>
            repo.GetAllCategoriesAync()).ReturnsAsync(GetCategorysTest(1));
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result =await  controller.GetCategorys();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllCategorys_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockCategoryRepo.Setup(repo =>
            repo.GetAllCategoriesAync()).ReturnsAsync(GetCategorysTest(1));
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result =await  controller.GetCategorys();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<CategoryDto>>>(result);
        }

        [Fact]
        public async Task GetCategoryByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            var id = new Guid("00000000-0000-0000-0000-000000000000");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync( new Category
            {
                
            });

                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetCategory(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetCategoryByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
            {
                
            });

                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetCategory(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetCategoryByID_Returns200OK__WhenValidIDProvided_()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
            {
                
            });

                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetCategory(id);

            //Assert
            Assert.IsType<ActionResult<CategoryDto>>(result);
        }

        [Fact]
        public async Task CreateCategory_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
            {
                CategoryId = id,
              
            });

                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.CreateCategory(new CategoryForCreateDto { });

            //Assert
            //Assert.IsType<ActionResult<CategoryDto>>(result);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task CreateCategory_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
            {
                
            });

                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.CreateCategory(new CategoryForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        // [Fact]
        // public async Task UpdateCategory_Returns204NoContent_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
        //     mockCategoryRepo.Setup(repo =>
        //     repo.CategoryIfExistsAsync(id)).ReturnsAsync(true);

        //     mockCategoryRepo.Setup(repo =>
        //     repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
        //     {
        //         CategoryId= id,
              
        //     });

        //         var controller = new CategoryController(
        //    mockCategoryRepo.Object,
        //     mockMail.Object ,
        //     mockConfig.Object,
        //     mockWeHost.Object,
        //                mapper
        //     );

        //     //Act
        //     var result = await controller.UpdateCategory(id, new CategoryForUpdateDto { });

        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        [Fact]
        public async Task UpdateCategory_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(() => null);
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);


            //Act
            var result = await controller.UpdateCategory(id, new CategoryForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PartialCategoryUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(() => null);
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.PartiallyUpdateCategory(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<CategoryForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCategory_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
            mockCategoryRepo.Setup(repo =>
            repo.CategoryIfExistsAsync(id)).ReturnsAsync(true);

            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(new Category
            {
                CategoryId= id,
               
            });            
                
                var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);
            
            //Act
            var result = await controller.DeleteCategory(id);
            
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCategory_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {

            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockCategoryRepo.Setup(repo =>
            repo.GetCategoryByIdAsync(id)).ReturnsAsync(() => null);
            
            var controller = new CategoryController(mockCategoryRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.DeleteCategory(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}