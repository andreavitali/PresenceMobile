using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EncodedPassword { get; set; }
        public int? RoleId { get; set; }
        public virtual Person Person { get; set; }
        public int? PersonId { get; set; }
    }
}