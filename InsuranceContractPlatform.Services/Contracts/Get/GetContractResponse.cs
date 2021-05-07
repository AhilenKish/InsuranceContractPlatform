using InsuranceContractPlatform.DataServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contracts.Get
{
    public class GetContractResponse
    {
        public List<Contractor> Contractors { get; set; }
    }
}
