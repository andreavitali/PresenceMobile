using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Presence.Entities.Models;

namespace Presence.EFDataServices.Mappings
{
    internal class CauseMap : EntityTypeConfiguration<Cause>
    {
        public CauseMap(string schema)
        {
            this.ToTable("CAUSALI", schema);
            this.Property(c => c.Id).HasColumnName("CAUSID");
            this.Property(c => c.Code).HasColumnName("CODCAUSALE");
            this.Property(c => c.Description).HasColumnName("DESCRIZIONE");
            this.Property(c => c.Presence).HasColumnName("PRESENZA");
            this.Property(c => c.Overtime).HasColumnName("STRAORDINARIO");
            this.Property(c => c.IgnoreInTimeAmount).HasColumnName("IGNORANELMO");
            this.Property(c => c.Grade).HasColumnName("GRADO");
        }
    }
}
