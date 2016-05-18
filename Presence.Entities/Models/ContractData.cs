using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public class ContractData
    {
        public string CompanyCode { get; set; }
        public string SiteCode { get; set; }
        public string DepartmentCode { get; set; }
        public string GroupCode { get; set; }
        public string TagCode { get; set; }
        public string QualificationCode { get; set; }
        public string DefaultCostCenter { get; set; }
        public string EmploymentTermCode { get; set; }
        public string ContractTypeCode { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Company='{0}', ", CompanyCode);
            sb.AppendFormat("Site='{0}', ", SiteCode);
            sb.AppendFormat("Dept.='{0}', ", DepartmentCode);
            sb.AppendFormat("Group='{0}', ", GroupCode);
            sb.AppendFormat("Tag='{0}', ", TagCode);
            sb.AppendFormat("Qual.='{0}', ", QualificationCode);
            sb.AppendFormat("Cost='{0}', ", DefaultCostCenter);
            sb.AppendFormat("EmpTerm='{0}', ", EmploymentTermCode);
            sb.AppendFormat("ContrType='{0}'", ContractTypeCode);

            return sb.ToString();
        }
    }
}
