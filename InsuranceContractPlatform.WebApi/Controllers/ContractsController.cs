using InsuranceContractPlatform.DataServices.Entities;
using InsuranceContractPlatform.Services.Contracts.Get;
using InsuranceContractPlatform.Services.Contracts.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.WebApi.Controllers
{
    public class ContractsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<GetContractResponse>> GetContractors()
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Bad Request");
            }
            return await Mediator.Send(new GetContractServices());
        }

        [HttpPost("create")]
        public async Task<ActionResult<PostContractResponse>> Create(PostContractRequest contractorDto)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Bad Request");
            }

            var response = await Mediator.Send(new PostContractServices() { Contractors = contractorDto.Contractors , IsRemoved  = false});
            if (response.ContractExists)
            {
                return BadRequest("Contract already exists!");
            }
            else
            {
                return response;
            }
        }

        [HttpPost("remove")]
        public async Task<ActionResult<PostContractResponse>> Remove(PostContractRequest contractorDto)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Bad Request");
            }
            var response = await Mediator.Send(new PostContractServices() { Contractors = contractorDto.Contractors, IsRemoved = true });
            if (response.ContractExists)
            {
                return BadRequest("Contract already exists!");
            }
            else
            {
                return response;
            }
        }
    }
}
