using Microsoft.AspNetCore.Http;
using Renato.ECommerce.Domain.Enums;
using Renato.ECommerce.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renato.ECommerce.WebUI
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static readonly HttpContextAccessor accessor = new HttpContextAccessor();

        public bool IsInRole(Role role)
        {
            return accessor.HttpContext.User.IsInRole(role.ToString());
        }
    }
}
