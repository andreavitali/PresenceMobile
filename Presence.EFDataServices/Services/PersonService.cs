using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;
using System.Linq.Expressions;

namespace Presence.EFDataServices
{
    public class PersonService : IPersonService
    {
        private readonly PresenceDataContext _context;
        private readonly IUserManagementService _userManagementService;
        private readonly ISettingsService _settingsService;

        public PersonService(PresenceDataContext context, IUserManagementService userManagementService, ISettingsService settingsService)
        {
            _context = context;
            _userManagementService = userManagementService;
            _settingsService = settingsService;
        }

        public Person GetById(int personId)
        {
            return _context.Set<Person>().Include("ServiceIntervals").SingleOrDefault(p => p.Id == personId);
        }

        public IQueryable<Person> GetAll()
        {
            return _context.Set<Person>().AsNoTracking();
        }

        public IQueryable<Person> GetVisible<TKey>(Expression<Func<Person, bool>> filterPredicate = null, Expression<Func<Person, TKey>> orderPredicate = null, 
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var currentLoggedUser = _userManagementService.LoggedUser;
            if (currentLoggedUser == null)
                return Enumerable.Empty<Person>().AsQueryable();

            IQueryable<Person> persons = _context.Set<Person>();

            // Custom filter
            if (filterPredicate != null)
                persons = persons.Where(filterPredicate);

            // Sort
            if (orderPredicate != null)
                persons = persons.OrderBy(orderPredicate);

            return persons;
        }
    }
}
