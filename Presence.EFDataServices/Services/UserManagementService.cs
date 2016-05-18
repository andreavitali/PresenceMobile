using System;
using System.Linq;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;

namespace Presence.EFDataServices
{
    public class UserManagementService : IUserManagementService
    {
        private readonly PresenceDataContext _context;
        private readonly ISettingsService _settingsService;
        private Account _currentLoggedUser = null;

        #region IUserManagementService Members

        public UserManagementService(PresenceDataContext context, ISettingsService settingsService)
        {
            _context = context;
            _settingsService = settingsService;
        }

        public void LoginUser(string userName, string password, string clientName, string OSUser)
        {
            _currentLoggedUser = _context.Set<Account>().SingleOrDefault(a => a.Username.ToLower() == userName.ToLower());

            if (_currentLoggedUser == null)
                throw new Exception("Unknown user");
        }

        public void LogoutUser()
        {
            _currentLoggedUser = null;
        }

        public Account LoggedUser
        {
            get { return _currentLoggedUser; }
        }
        #endregion
    }
}
