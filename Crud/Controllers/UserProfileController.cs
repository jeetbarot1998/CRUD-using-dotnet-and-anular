using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// The JWT Token is stored in the local storage of the browser, we have to send the same token to access
// secure or private routes inside this "CRUD" project. 
// Thus it is convenient to add a new controller to handle UserProfileController
namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        // API method to return details of signed in like UserName,Emial id, Name etc. Thus Get type
        [HttpGet]
        [Authorize]
        [EnableCors("AllowOrigin")]
        //GET: api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            // This method needs to extract the payload from the "UserID" claim mentioned in the UserProfileController.cs
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

    }
}
