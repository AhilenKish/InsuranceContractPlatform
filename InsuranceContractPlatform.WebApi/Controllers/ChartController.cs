using InsuranceContractPlatform.Services.Chart.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.WebApi.Controllers
{
    public class ChartController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<GetChartResponse>> GetContractors()
        {
            return await Mediator.Send(new GetChartServices());
        }
    
    }
}
