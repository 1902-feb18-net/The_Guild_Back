using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using The_Guild_Back.API.Models;
using The_Guild_Back.DAL;

namespace The_Guild_Back.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(SignInManager<IdentityUser> signInManager,
            AuthDbContext dbContext, ILogger<AccountController> logger)
        {
            // we can do code-first "skipping" migrations at runtime
            // the downside is, we can't run migrations on the database that gets generated
            // later.
            dbContext.Database.EnsureCreated();
            SignInManager = signInManager;
            _logger = logger;
        }

        // POST for create resource, but also for "perform operation"
        // when there is no way to fit the operation into CRUD terms.
        // POST /account/login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await SignInManager.PasswordSignInAsync(
                login.Username, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                return Unauthorized(); // 401 for login failure
            }

            return NoContent();
        }

        // POST /account/logout
        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return NoContent();
        }

        // POST /account
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser register,
            [FromServices] UserManager<IdentityUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager)
        {
            var user = new IdentityUser(register.Username);

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded) // e.g. did not meet password policy
            {
                return BadRequest(result);
            }

            if(register.IsMaster)
            {
                if(!await roleManager.RoleExistsAsync("master"))
                {
                    var role = new IdentityRole("master");
                    IdentityResult identityResult = await roleManager.CreateAsync(role);
                    if(!identityResult.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "master role not created");
                    }
                }

                IdentityResult addResult = await userManager.AddToRoleAsync(user, "master");
                if(!addResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to make guild master");
                }
            }

            await SignInManager.SignInAsync(user, false);

            return NoContent(); // nothing to show the user that he can access
        }

        // PUT /account/update/5
        [HttpPut("[action]")]
        [Authorize]
        public async Task<IActionResult> AssignRole(string id,
            string role,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            IdentityResult result = await userManager.AddToRoleAsync(user, role);

            if(!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "unable to update user permissions");
            }
            return NoContent();
        }

        // POST /account/roles
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Roles(
            [FromServices] RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("receptionist"))
            {
                var role = new IdentityRole("receptionist");
                IdentityResult identityResult = await roleManager.CreateAsync(role);
                if (!identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "receptionist role not created");
                }
            }

            if (!await roleManager.RoleExistsAsync("adventurer"))
            {
                var role2 = new IdentityRole("adventurer");
                IdentityResult identityResult = await roleManager.CreateAsync(role2);
                if (!identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "adventurer role not created");
                }
            }
            return NoContent();
        }
    }
}