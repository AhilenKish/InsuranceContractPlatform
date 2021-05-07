using InsuranceContractPlatform.DataServices.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contractors.Get
{
    public class GetContractorServices : GetContractorRequest
    {
    }

    public class GetContractorServicesHandler : IRequestHandler<GetContractorServices, GetContractorResponse>
    {
        private readonly DataContext _context;

        public GetContractorServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetContractorResponse> Handle(GetContractorServices request, CancellationToken cancellationToken)
        {
            var response = new GetContractorResponse();
            response.Contractors = await _context.Contractors.ToListAsync();
            return response;

        }
    }
}
