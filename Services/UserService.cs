using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pathology.Services
{
    public class UserService: IUserService
    {
        private readonly IHttpContextAccessor _HttpContext;
            
            public UserService(IHttpContextAccessor HttpContext)
            {
                _HttpContext = HttpContext;
            }
        public string GetUserID()
        {
            return _HttpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
        }
    }
}
