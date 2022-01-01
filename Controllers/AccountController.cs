using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.netcore.Model;
using Webapi.netcore.Repository;

namespace Webapi.netcore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost]
        public async Task<IActionResult> signUp([FromBody]Registration registration)
        {
       var result= await _accountRepository.signUp(registration);
            if (result.Succeeded)
            { 
                return Ok("Success");
            }
            
                return Unauthorized();

        }
    }
}
