using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureREST.Controllers
{
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager { get; }

        // we're gonna handwave over REST uniform interface for authentication type stuff
        //[HttpPost]
        //public async Task<IActionResult> AccountController(SignInManager<IdentityUser> signInManager)
        //{
        //    _signInManager = signInManager;

        //}

        // set up a register function. 
        // set up registration for user with userManager and role manager with  RoleManager.

    }
}
