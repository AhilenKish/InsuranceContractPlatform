using InsuranceContractPlatform.DataServices.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contracts.Post
{
    public class PostContractRequest : IRequest<PostContractResponse>
    {
        // ContractorIds
        public List<Contractor> Contractors { get; set; }
        public bool IsRemoved { get; set; }
    }
}
