using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTExample.Models;
using JWTExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenExample.DBContext;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "User was not found" });
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refreshToken")]
        public IActionResult RefreshToken(RefreshRequest request)
        {
            var response = _userService.RefreshToken(request);
            if (response==null)
            {
                return BadRequest(new { message = "Invalid token" });
            }
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("revokeRefreshToken")]
        public IActionResult RevokeRefreshToken(RefreshRequest request)
        {
            bool response = _userService.RevokeRefreshToken(request);
            if (!response)
            {
                return Unauthorized();
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("getWeather")]
        public IActionResult GetWeather()
        {
            var request = Request;
            var headers = request.Headers;

            if (headers.Keys.Contains("Custom"))
            {
                string token = headers["Custom"];
            }

            return null;
        }




        [HttpGet("mert")]
        public string Mert()
        {
            return "Mert";
        }



    }
}
