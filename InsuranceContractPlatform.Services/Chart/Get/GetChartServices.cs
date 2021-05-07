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

namespace InsuranceContractPlatform.Services.Chart.Get
{
    public class GetChartServices : GetChartRequest
    {
    }

    public class GetChartServicesHandler : IRequestHandler<GetChartServices, GetChartResponse>
    {
        private readonly DataContext _context;

        public GetChartServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetChartResponse> Handle(GetChartServices request, CancellationToken cancellationToken)
        {
            var contractors = await (from x in _context.Contractors
                                      join c in _context.ContractDetails
                                      on x.Id equals c.ContractorId
                                      group x by new { x.Id ,x.Name } into g
                                     select new ContactorsChart()
                                     {
                                        Id = g.Key.Id,
                                        Name = g.Key.Name,
                                        ContractCount = g.Count()
                                     }).ToListAsync();

            GetChartResponse response = new GetChartResponse();
            response.Contractors = contractors;

            return response;


        }
    }
}
