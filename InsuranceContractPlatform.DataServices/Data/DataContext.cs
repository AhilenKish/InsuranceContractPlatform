using InsuranceContractPlatform.DataServices.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.DataServices.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<ContractorType> ContractorTypes { get; set; }
        public DbSet<InsuranceContract> Contracts { get; set; }
        public DbSet<InsuranceContractDetails> ContractDetails { get; set; }
        public DbSet<ContactorsChart> Chart { get; set; }
    }
}
