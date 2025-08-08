using AutoInsurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Infrastructure.Configurations
{
    internal class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasData(
                new Policy
                {
                    Id = 1,
                    PolicyNumber = "POL123456",
                    BeneficiaryName = "John Doe",
                    CarBrand = "Honda",
                    CarType = "Brio Satya",
                    TSI = 120_000_000m,
                    PremiumRate = 2.0m,
                    PremiumAmount = 2_400_000m,
                    StartDate = new DateTime(2025,1,1),
                    EndDate = new DateTime(2026,1,1)
                }
            );
        }
    }
}
