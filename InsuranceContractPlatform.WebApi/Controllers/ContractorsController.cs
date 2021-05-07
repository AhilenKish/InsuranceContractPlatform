using InsuranceContractPlatform.DataServices.Data;
using InsuranceContractPlatform.DataServices.Entities;
using InsuranceContractPlatform.Services.Contractors.Get;
using InsuranceContractPlatform.Services.Contractors.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.WebApi.Controllers
{
   
    public class ContractorsController : BaseApiController
    {

        [HttpPost("create")]
        public async Task<ActionResult<PostContractorResponse>> Create(Contractor contractorDto)
        {
       
            var response =  await Mediator.Send(new PostContractorServices(){ Contractor = contractorDto });
            if (response.ContractorExists)
            {
                return BadRequest("Contractor already exists!");
            }
            else
            {
                return response;
            }
        }
    }
}
