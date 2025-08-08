using AutoInsurance.Domain.Entities;
using AutoInsurance.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Infrastructure
{
    public class AutoInsuranceDbContext : IdentityDbContext
    {
        public AutoInsuranceDbContext(DbContextOptions<AutoInsuranceDbContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Additional model configurations can be added here
            builder.ApplyConfiguration(new PolicyConfiguration());
        }
        public DbSet<Policy> Policies { get; set; }
    }
}
