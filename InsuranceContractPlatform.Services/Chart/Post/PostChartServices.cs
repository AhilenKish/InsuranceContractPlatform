using InsuranceContractPlatform.DataServices.Data;
using InsuranceContractPlatform.DataServices.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Chart.Post
{
    public class PostChartServices: PostChartRequest
    {
        
    }

    public class GetRelationshipServicesHandler : IRequestHandler<PostChartServices, PostChartResponse>
    {
        private readonly DataContext _context;

        public GetRelationshipServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<PostChartResponse> Handle(PostChartServices request, CancellationToken cancellationToken)
        {
            PostChartResponse respnse = new PostChartResponse();

            var v = await (from f in _context.Contracts
                           join j in _context.ContractDetails on f.Id equals j.InsuranceContractId
                           group f by new { f.Id,f.Description } into g
                           select new ContactorsChart()
                           {
                               Id = g.Key.Id,
                               Name = g.Key.Description
                           }).ToListAsync();

            //respnse.RelationShip = string.Join("\\n", v);
            respnse.RelationShip = v;

            return respnse;
        }
    }
}
