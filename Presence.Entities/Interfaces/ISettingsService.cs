using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Presence.Entities.Models;

namespace Presence.Entities.Interfaces
{
    public interface ISettingsService
    {
        byte[] MajorAnomalies { get; }
        bool HistorySupport { get; }
    }
}
