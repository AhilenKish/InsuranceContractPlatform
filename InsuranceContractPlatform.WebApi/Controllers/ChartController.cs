using InsuranceContractPlatform.Services.Chart.Get;
using InsuranceContractPlatform.Services.Chart.Post;
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
            if(!this.ModelState.IsValid)
            {
                return BadRequest("Bad Request");
            }

            return await Mediator.Send(new GetChartServices());
        }

        [HttpPost]
        public async Task<ActionResult<PostChartResponse>> PostContractors(PostChartRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Bad Request");
            }
            return await Mediator.Send(new PostChartServices() { Id = request.Id });
        }
    }
}
