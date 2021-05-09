using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Chart.Post
{
    public class PostChartRequest: IRequest<PostChartResponse>
    {
        public int Id { get; set; }
    }
}
