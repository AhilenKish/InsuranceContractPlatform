using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contracts.Post
{
    public class PostContractResponse
    {
        public bool ContractExists { get; set; }
        public bool ContractRemoved { get;  set; }
    }
}
