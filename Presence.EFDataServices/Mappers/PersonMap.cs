using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Models;
using System.Data.Entity.ModelConfiguration;

namespace Presence.EFDataServices.Mappings
{
    internal class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap(string schema)
        {
            this.ToTable("DIPENDENTI", schema);
            this.Property(p => p.Id).HasColumnName("DIPID");
            this.Property(p => p.FirstName).HasColumnName("NOME");
            this.Property(p => p.LastName).HasColumnName("COGNOME");
            this.Property(p => p.BadgeCode).HasColumnName("BADGE");
            this.Property(p => p.Matricula).HasColumnName("MATRICOLA");
        }
    }
}
