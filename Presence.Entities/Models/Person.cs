using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeCode { get; set; }
        public string Matricula { get; set; }
        public virtual List<ServiceInterval> ServiceIntervals { get; set; }

        public override string ToString( )
        {
            return string.Format("{0} {1} {2}", this.Id, this.LastName, this.FirstName);
        }
    }

    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return (x.Id == y.Id);
        }

        public int GetHashCode(Person obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
