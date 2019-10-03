using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleManager<IdentityRole> roleManager;
       
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addRole([FromBody] RoleModel model)
        {
            var role = await roleManager.FindByNameAsync(model.Name);
            if (role == null)
            {
                var appRole = new IdentityRole() { Name = model.Name };
                var result = await roleManager.CreateAsync(appRole);
                return Ok(new
                {
                    result
                });
            }
            else
            {
                return Conflict();
            }
        }
    }
}