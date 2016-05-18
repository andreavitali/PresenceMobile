using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;

namespace Presence.EFDataServices
{
    public class LookupService : ILookupService
    {
        private readonly PresenceDataContext _context;

        public LookupService(PresenceDataContext context)
        {
            _context = context;
        }

        public IQueryable<TLookup> GetAll<TLookup>() where TLookup : BaseLookupEntity, new()
        {
            return _context.Set<TLookup>();
        }

        public TLookup GetByCode<TLookup>(string code) where TLookup : BaseLookupEntity, new()
        {
            return _context.Set<TLookup>().SingleOrDefault(l => l.Code == code);
        }
    }
}
