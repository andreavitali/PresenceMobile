using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Presence.Entities.Models;

namespace Presence.EFDataServices.Mappings
{
    internal class ServiceIntervalMap : EntityTypeConfiguration<ServiceInterval>
    {
        public ServiceIntervalMap(string schema)
        {
            this.ToTable("PERIODISERVIZIO", schema);
            this.Property(si => si.Id).HasColumnName("PERSERVID");
            this.Property(si => si.PersonId).HasColumnName("DIPID");
            this.Property(si => si.Comment).HasColumnName("COMMENTO");
            this.Property(si => si.HireDate).HasColumnName("DATAASSUNZ");
            this.Property(si => si.QuitDate).HasColumnName("DATACESSAZ");
        }
    }
}
