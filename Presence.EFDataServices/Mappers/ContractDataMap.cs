using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.Entities.Models;
using System.Data.Entity.ModelConfiguration;

namespace Presence.EFDataServices.Mappings
{
    internal class ContractDataMap : ComplexTypeConfiguration<ContractData>
    {
        public ContractDataMap()
        {
            this.Property(cd => cd.CompanyCode).HasColumnName("CODAZIENDA");
            this.Property(cd => cd.SiteCode).HasColumnName("CODSTABILIMENTO");
            this.Property(cd => cd.DepartmentCode).HasColumnName("CODREPARTO");
            this.Property(cd => cd.GroupCode).HasColumnName("CODGRUPPO");
            this.Property(cd => cd.TagCode).HasColumnName("CODCARTELLINO");
            this.Property(cd => cd.QualificationCode).HasColumnName("CODQUALIFICA");
            this.Property(cd => cd.DefaultCostCenter).HasColumnName("CODCDC");
            this.Property(cd => cd.EmploymentTermCode).HasColumnName("CODNATURARAPPORTO");
            this.Property(cd => cd.ContractTypeCode).HasColumnName("CODTIPOCONTRATTO");
        }
    }
}