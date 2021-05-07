using InsuranceContractPlatform.DataServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contractors.Post
{
    public class PostContractorResponse
    {
        public bool ContractorExists { get;  set; }
        public List<Contractor> Contractors { get; set; }
    }
}
