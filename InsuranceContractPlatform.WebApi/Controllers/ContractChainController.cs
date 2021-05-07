using InsuranceContractPlatform.Services.ContractChain.Post;
using InsuranceContractPlatform.Services.Contracts.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.WebApi.Controllers
{
    public class ContractChainController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<GetContractResponse>> GetContractors()
        {
            return await Mediator.Send(new GetContractServices());
        }

        [HttpPost("chain")]
        public async Task<ActionResult<PostContractChainResponse>> Create(PostContractChainRequest contractorDto)
        {
            var response = await Mediator.Send(new PostContractChainServices() { Contractors = contractorDto.Contractors });
            return response;
        }
    }
}
