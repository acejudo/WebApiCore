using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel userModel)
        {
           /* var user = await userManager.FindByNameAsync(appUser.UserName);
            if (user == null)
            {
                AppUser user = new AppUser
                {
                    Email = appUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = appUser.UserName
                };

                IdentityResult result = await userManager.CreateAsync(user, "Geralt12345!@");
                return Ok(user);
            }
            else
            {
                return Conflict();
            }*/
             return NotFound();
        }
    }
}