using AutoInsurance.Application.DTOs.Policy;
using AutoInsurance.Domain.Entities;
using AutoInsurance.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Services
{
    public class PolicyService
    {
        private readonly IPolicyRepository _repository;

        public PolicyService(IPolicyRepository repository)
        {
            _repository = repository;
        }

        public async Task <Policy> CreateAsync(CreatePolicyDto dto)
        {
            var policy = new Policy
            {
                PolicyNumber = GeneratePolicyNumber(),
                BeneficiaryName = dto.BeneficiaryName,
                CarBrand = dto.CarBrand,
                CarType = dto.CarType,
                TSI = dto.TSI,
                PremiumRate = dto.PremiumRate,
                PremiumAmount = CalculatePremiumAmount(dto.TSI,dto.PremiumRate),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            await _repository.AddAsync(policy);
            return policy;
        }
        private string GeneratePolicyNumber()
        {
            return $"POL-{DateTime.UtcNow:yyyyMMddHHmmssfff}";
        }
        private decimal CalculatePremiumAmount(decimal tsi, decimal premiumRate)
        {
            return (tsi * premiumRate / 100);
        }
    }
}
