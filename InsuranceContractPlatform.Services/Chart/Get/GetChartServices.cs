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
                                     group x by new { x.Id, x.Name } into g
                                     select new ContactorsChart()
                                     {
                                         Id = g.Key.Id,
                                         Name = g.Key.Name,
                                         ContractCount = g.Count()
                                     }).ToListAsync();

            //var relationShip = await (from x in _context.Contracts 
            //                         join j in _context.ContractDetails
            //                         on x.Id equals j.ContractorId
            //                         select x).ToListAsync();


            var relationShip = await (from f in _context.Contracts
                           join j in _context.ContractDetails on f.Id equals j.InsuranceContractId
                           group f by new { j.ContractorId, f.Description } into g
                           select new ContactorsChart()
                           {
                               Id = g.Key.ContractorId,
                               Name = g.Key.Description
                           }).ToListAsync();

            GetChartResponse response = new GetChartResponse();
            response.Contractors = contractors;
            response.Relationship = relationShip;
            return response;


        }
    }
}
