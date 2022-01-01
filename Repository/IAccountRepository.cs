using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.netcore.Model;

namespace Webapi.netcore.Repository
{
  public  interface IAccountRepository
    {
          Task<IdentityResult> signUp(Registration registration);
    }
}
