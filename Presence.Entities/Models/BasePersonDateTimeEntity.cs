using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public class BasePersonDateTimeEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public DateTime DateTime { get; set; }
    }
}
