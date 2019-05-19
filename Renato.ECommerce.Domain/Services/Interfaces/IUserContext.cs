using Renato.ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renato.ECommerce.Domain.Services.Interfaces
{
    public interface IUserContext
    {
        bool IsInRole(Role role);
    }
}
