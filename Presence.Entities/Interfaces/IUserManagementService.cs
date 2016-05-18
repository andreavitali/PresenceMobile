using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Presence.Entities.Models;

namespace Presence.Entities.Interfaces
{
    public interface IUserManagementService
    {
        void LoginUser(string userName, string password, string clientName, string OSUser);
        void LogoutUser();
        Account LoggedUser { get; }
    }
}
