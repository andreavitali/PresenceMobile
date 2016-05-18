using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;

namespace Presence.API.Controllers
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly IUserManagementService _userManagementService;

        public PersonsController(IPersonService personService, IUserManagementService userManagementService)
        {
            _personService = personService;
            _userManagementService = userManagementService;
        }

        public Person GetPerson(int id)
        {
            return _personService.GetById(id);
        }

        public IQueryable<Person> GetPersons()
        {
            if (_userManagementService.LoggedUser == null)
                _userManagementService.LoginUser("Admin", "Admin", System.Environment.MachineName, System.Environment.UserName);

            var persons = _personService.GetVisible<string>().OrderBy(p => p.BadgeCode);
            return persons;
        }

        //public IHttpActionResult Login(string user, string password)
        //{
        //    try
        //    {
        //        _userManagementService.LoginUser(user, password, System.Environment.MachineName, System.Environment.UserName);
        //    }
        //    catch (Exception)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok();
        //}
    }
}
