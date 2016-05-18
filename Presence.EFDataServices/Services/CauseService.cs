using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;

namespace Presence.EFDataServices
{
    public class CauseService : ICauseService
    {
        private readonly PresenceDataContext _context;

        public CauseService(PresenceDataContext context)
        {
            _context = context;
        }

        public Cause GetByCode(string code)
        {
            return _context.Set<Cause>().SingleOrDefault(c => c.Code == code);
        }   

        public IQueryable<Cause> GetAll()
        {
            return _context.Set<Cause>();
        }    

        public Cause GetById(int id)
        {
            return _context.Set<Cause>().SingleOrDefault(c => c.Id == id);
        }

        public IQueryable<Cause> Get(System.Linq.Expressions.Expression<Func<Cause, bool>> filterPredicate)
        {
            return GetAll().Where(filterPredicate);
        }

        public IQueryable<Cause> Get<TKey>(System.Linq.Expressions.Expression<Func<Cause, bool>> filterPredicate, System.Linq.Expressions.Expression<Func<Cause, TKey>> orderPredicate)
        {
            return Get(filterPredicate).OrderBy(orderPredicate);
        }
    }
}
