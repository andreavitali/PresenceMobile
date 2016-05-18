using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presence.Entities.Models
{
    public partial class Company : BaseLookupEntity
    {
        public bool IsExternal { get; set; }
    }

    public partial class Department : BaseLookupEntity
    {

    }

    public partial class Group : BaseLookupEntity
    {

    }

    public partial class Qualification : BaseLookupEntity
    {

    }

    public partial class Site : BaseLookupEntity
    {

    }

    public partial class Tag : BaseLookupEntity
    {

    }

    public partial class CostCenter : BaseIdCodeEntity
    {
        public short FieldId { get; set; }
    }

    public partial class EmploymentTerm : BaseLookupEntity
    {

    }

    public partial class ContractType : BaseLookupEntity
    {

    }
}
