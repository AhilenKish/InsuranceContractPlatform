using InsuranceContractPlatform.DataServices.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.ContractChain.Post
{
    public class PostContractChainRequest : IRequest<PostContractChainResponse>
    {
        public List<Contractor> Contractors { get; set; }
    }
}
