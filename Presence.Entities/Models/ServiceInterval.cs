using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public partial class ServiceInterval
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public string Comment { get; set; }

        public override string ToString( )
        {
            if (QuitDate.HasValue)
                return string.Format("{0:d} - {1:d}", HireDate, QuitDate);
            else
                return string.Format("{0:d} — ", HireDate);
        }

        public bool Includes(DateTime date)
        {
            return ((HireDate <= date) && (!QuitDate.HasValue || QuitDate >= date));
        }
    }
}
