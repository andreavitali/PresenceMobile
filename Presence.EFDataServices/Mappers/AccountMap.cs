using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Presence.Entities.Models;

namespace Presence.EFDataServices.Mappings
{
    internal class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap(string schema)
        {
            this.ToTable("ACCOUNTS", schema);
            this.Property(a => a.Id).HasColumnName("ACCOUNTID");
            this.Property(a => a.Username).HasColumnName("USERNAME");
            this.Property(a => a.EncodedPassword).HasColumnName("PASSWORD");
            this.Property(a => a.RoleId).HasColumnName("ROLEID");
            this.Property(a => a.PersonId).HasColumnName("DIPID");
        }
    }
}
