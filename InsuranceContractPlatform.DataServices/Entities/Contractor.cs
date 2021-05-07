using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.DataServices.Entities
{
    
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ContractorTypeId { get; set; }
        public int HealthStatusId { get; set; }
    }

    public class HealthStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
    }

    public class ContractorType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
