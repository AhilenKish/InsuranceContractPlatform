using InsuranceContractPlatform.DataServices.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contracts.Get
{
    public class GetContractServices : GetContractRequest
    {
    }

    public class GetContractServicesHandler : IRequestHandler<GetContractServices, GetContractResponse>
    {
        private readonly DataContext _context;

        public GetContractServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetContractResponse> Handle(GetContractServices request, CancellationToken cancellationToken)
        {
            var response = new GetContractResponse();
            response.Contractors = await _context.Contractors.ToListAsync();
            return response;

        }
    }
}
