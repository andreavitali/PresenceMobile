using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Models;

namespace Presence.Entities.Interfaces
{
    public interface ILookupService
    {
        IQueryable<TLookup> GetAll<TLookup>() where TLookup : BaseLookupEntity, new();
        TLookup GetByCode<TLookup>(string code) where TLookup : BaseLookupEntity, new();
    }
}
