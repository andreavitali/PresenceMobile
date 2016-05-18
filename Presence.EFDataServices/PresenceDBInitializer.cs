using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Presence.EFDataServices;
using Presence.Entities.Models;

namespace Presence.EFDataServices
{
    public class PresenceDBInitializer : CreateDatabaseIfNotExists<PresenceDataContext>
    {
        protected override void Seed(PresenceDataContext context)
        {
            // Account
            context.Set<Account>().Add(new Account() { Id = 1, Username = "Admin" });
            
            // Persons
            var p1ServiceIntervals = new List<ServiceInterval>();
            p1ServiceIntervals.Add(new ServiceInterval() { Id = 1, HireDate = new DateTime(2010, 1, 1), QuitDate = new DateTime(2015, 12, 31) });
            p1ServiceIntervals.Add(new ServiceInterval() { Id = 2, HireDate = new DateTime(2016, 1, 1) });
            var p1 = new Person() { Id = 1, FirstName = "Andrea", LastName = "Vitali", BadgeCode = "00001", Matricula = "123456", ServiceIntervals = p1ServiceIntervals };

            var p2ServiceIntervals = new List<ServiceInterval>();
            p2ServiceIntervals.Add(new ServiceInterval() { Id = 3, HireDate = new DateTime(2014, 6, 1) });
            var p2 = new Person() { Id = 2, FirstName = "Mario", LastName = "Rossi", BadgeCode = "00002", Matricula = "436926", ServiceIntervals = p2ServiceIntervals };

            var p3ServiceIntervals = new List<ServiceInterval>();
            p3ServiceIntervals.Add(new ServiceInterval() { Id = 4, HireDate = new DateTime(2015, 1, 1) });
            var p3 = new Person() { Id = 3, FirstName = "Luca", LastName = "Bianchi", BadgeCode = "00003", Matricula = "235907", ServiceIntervals = p3ServiceIntervals };

            context.Set<Person>().Add(p1);
            context.Set<Person>().Add(p2);
            context.Set<Person>().Add(p3);

            base.Seed(context);
        }
    }
}
