namespace AutoInsurance.Application.DTOs.Policy
{
    public class CreatePolicyDto
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string BeneficiaryName { get; set; } = string.Empty;
        public string CarBrand { get; set; } = string.Empty;
        public string CarType { get; set; } = string.Empty;
        public decimal TSI { get; set; }
        public decimal PremiumRate { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}