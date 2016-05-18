using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Presence.Entities.Models;

namespace Presence.Entities.Interfaces
{
    public interface IPersonService
    {
        Person GetById(int id);
        IQueryable<Person> GetAll();
        IQueryable<Person> GetVisible<TKey>(Expression<Func<Person, bool>> filterPredicate = null, Expression<Func<Person, TKey>> orderPredicate = null, 
            DateTime? startDate = null, DateTime? endDate = null);
    }

}
