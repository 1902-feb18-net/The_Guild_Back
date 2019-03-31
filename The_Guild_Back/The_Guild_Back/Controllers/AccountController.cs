using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(SignInManager<IdentityUser> signInManager,
            AuthDbContext dbContext, ILogger<AccountController> logger)
        {
            //dbContext.Database.EnsureCreated();
            SignInManager = signInManager;
            _logger = logger;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public ApiAccountDetails Details()
        {
            // if we want to know which user is logged in or which roles he has
            // apart from [Authorize] attribute...
            // we have User.Identity.IsAuthenticated
            // User.IsInRole("admin")
            // User.Identity.Name
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("");
                return null;
            }
            var details = new ApiAccountDetails
            {
                Username = User.Identity.Name,
                Roles = User.Claims.Where(c => c.Type == ClaimTypes.Role)
                                   .Select(c => c.Value)
            };
            return details;
        }

        // POST for create resource, but also for "perform operation"
        // when there is no way to fit the operation into CRUD terms.
        // POST azureyurl/api/account/login
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
        [HttpPost("[action]")]
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

            await SignInManager.SignInAsync(user, false);

            return NoContent(); // nothing to show the user that he can access
        }

        // PUT /account/update/5
        [HttpPut("[action]")]
        [Authorize(Roles = "master")]
        public async Task<IActionResult> AssignRole(string id,
            string role,
            [FromServices] UserManager<IdentityUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            IdentityResult result = await userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
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
            [FromServices] RoleManager<IdentityRole> roleManager,
            [FromServices] UserManager<IdentityUser> userManager)
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

            if (!await roleManager.RoleExistsAsync("master"))
            {
                var role3 = new IdentityRole("master");
                IdentityResult identityResult = await roleManager.CreateAsync(role3);
                if (!identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "master role not created");
                }
            }

            if (!await roleManager.RoleExistsAsync("user"))
            {
                var role4 = new IdentityRole("user");
                IdentityResult identityResult = await roleManager.CreateAsync(role4);
                if(!identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "base user role not created");
                }
            }

            var Lee = "Lunk";
            if (await userManager.FindByIdAsync(Lee) is null)
            {
                var leeUser = new IdentityUser(Lee); //FindByNameAsync(Lee).Result;


                IdentityResult result = await userManager.CreateAsync(leeUser, "NamineHano23#");

                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to seed user");
                }
                
                IdentityResult addRoleResult = await userManager.AddToRoleAsync(leeUser, "master");
                if (!addRoleResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to add user to admin role");
                }
            }

            return NoContent();
        }
    }
}