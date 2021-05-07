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

namespace InsuranceContractPlatform.Services.Contractors.Post
{
    public class PostContractorServices : PostContractorRequest
    {
    }

    public class PostContractorServicesHandler : IRequestHandler<PostContractorServices, PostContractorResponse>
    {
        private readonly DataContext _context;

        public PostContractorServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<PostContractorResponse> Handle(PostContractorServices request, CancellationToken cancellationToken)
        {
            var response = new PostContractorResponse();

            if (await ContractorExists(request.Contractor))
            {
                response.ContractorExists = true;
                return response;
            }

            var contractor = new Contractor
            {
                Name = request.Contractor.Name,
                Address = request.Contractor.Address,
                PhoneNumber = request.Contractor.PhoneNumber,
                ContractorTypeId = request.Contractor.ContractorTypeId,
                HealthStatusId = GetRandomlyGeneratedHealthStatus()
            };

            _context.Contractors.Add(contractor);
            await _context.SaveChangesAsync();

            response.Contractors = await _context.Contractors.ToListAsync();

            return response;

        }

        private int GetRandomlyGeneratedHealthStatus()
        {
            return new Random().Next(HealthStatuses().Count + 1);
        }

        public List<HealthStatus> HealthStatuses()
        {
            return new List<HealthStatus>()
            {
                new HealthStatus() { Id = 1 , Code = "Green", Value = 60 },
                new HealthStatus() { Id = 2 , Code = "Yellow", Value = 20 },
                new HealthStatus() { Id = 3 , Code = "Red", Value = 20 },
            };
        }

        private async Task<bool> ContractorExists(Contractor contractor)
        {
            return await _context.Contractors.AnyAsync(c => c.Name.ToLower() == contractor.Name.ToLower() &&
                                                            c.Address.ToLower() == contractor.Address.ToLower() &&
                                                            c.PhoneNumber.ToLower() == contractor.PhoneNumber.ToLower() &&
                                                            c.ContractorTypeId == contractor.ContractorTypeId);
        }
    }
}
