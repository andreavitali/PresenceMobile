using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public partial class Cause : BaseIdCodeEntity
    {
        public bool Presence { get; set; }
        public bool Overtime { get; set; }
        public bool IgnoreInTimeAmount { get; set; }
        public byte Grade { get; set; }
    }
}
