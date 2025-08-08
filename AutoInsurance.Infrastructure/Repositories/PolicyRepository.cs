using AutoInsurance.Domain.Entities;
using AutoInsurance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly AutoInsuranceDbContext _context;

        public PolicyRepository(AutoInsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
            => await _context.Policies.ToListAsync();

        public async Task<Policy?> GetByIdAsync(int id)
            => await _context.Policies.FindAsync(id);

        public async Task AddAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Policy policy)
        {
            _context.Policies.Update(policy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Policy policy)
        {
            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
        }
    }
}
