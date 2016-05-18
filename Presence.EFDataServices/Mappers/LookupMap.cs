using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Presence.Entities.Models;

namespace Presence.EFDataServices.Mappings
{
    public partial class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap(string schema)
        {
            this.ToTable("Aziende", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodAzienda");
            this.Property(l => l.Description).HasColumnName("Descrizione");
            this.Property(l => l.IsExternal).HasColumnName("FlgEsterna");
        }
    }

    public partial class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap(string schema)
        {
            this.ToTable("Reparti", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodReparto");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap(string schema)
        {
            this.ToTable("Gruppi", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodGruppo");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class QualificationMap : EntityTypeConfiguration<Qualification>
    {
        public QualificationMap(string schema)
        {
            this.ToTable("Qualifiche", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodQualifica");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class SiteMap : EntityTypeConfiguration<Site>
    {
        public SiteMap(string schema)
        {
            this.ToTable("Stabilimenti", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodStabilimento");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap(string schema)
        {
            this.ToTable("Cartellini", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class CostCenterMap : EntityTypeConfiguration<CostCenter>
    {
        public CostCenterMap(string schema)
        {
            this.ToTable("CentriDiCosto", schema);
            this.HasKey(l => l.Id);
            this.Property(l => l.Id).HasColumnName("CdCID");
            this.Property(l => l.FieldId).HasColumnName("IDCampo");
            this.Property(l => l.Code).HasColumnName("Codice");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class EmploymentTermMap : EntityTypeConfiguration<EmploymentTerm>
    {
        public EmploymentTermMap(string schema)
        {
            this.ToTable("NatureRapporto", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodNaturaRapporto");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

    public partial class ContractTypeMap : EntityTypeConfiguration<ContractType>
    {
        public ContractTypeMap(string schema)
        {
            this.ToTable("TipiContratto", schema);
            this.HasKey(l => l.Code);
            this.Property(l => l.Code).HasColumnName("CodTipoContratto");
            this.Property(l => l.Description).HasColumnName("Descrizione");
        }
    }

}
