﻿using AutoMapper;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Helpers;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
namespace KhotsoCBookStore.API.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
          private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        readonly ICartService _cartService;

        public UserController(IUserService userService, ICartService cartService, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(_userService));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));;
            _appSettings = appSettings.Value;
            _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));;
        }


        /// <summary>
        /// Check username availability. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("validateUserName/{userName}")]
        public bool ValidateUserName(string userName)
        {
            return _userService.CheckUserAvailabity(userName);
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="model"></param>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto model)
        {
            var user = _mapper.Map<UserMaster>(model);
            try
            {
                // create user
                _userService.RegisterUser(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
