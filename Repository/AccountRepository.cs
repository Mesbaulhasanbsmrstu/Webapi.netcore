using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.netcore.DataFolder;
using Webapi.netcore.Model;

namespace Webapi.netcore.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        public AccountRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> signUp(Registration registration)
        {
            var user = new User()
            {
                FirstName = registration.FirstName,
                LastName = registration.Lastname,
                Email = registration.Email,
                UserName = registration.Email
            };
            return await _userManager.CreateAsync(user, registration.Password);
        }
    }
}
