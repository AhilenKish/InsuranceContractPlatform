using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.DataServices.Entities
{
    public class ContactorsChart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContractCount { get; set; }
    }
}
