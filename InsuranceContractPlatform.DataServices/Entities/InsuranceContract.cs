using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.DataServices.Entities
{
    public class InsuranceContract
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class InsuranceContractDetails
    {
        public int Id { get; set; }
        public int InsuranceContractId { get; set; }
        public int ContractorId { get; set; }
    }
}
