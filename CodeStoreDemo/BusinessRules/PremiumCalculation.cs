using CodeStoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.BusinessRules
{
    public static class PremiumCalculation
    {
        // Calculate Premium
        public static CalculatePremiumResult Calculate(double _carValue, double _premiumPercentage, double _taxPercentage)
        {
            var premiumResponse = new CalculatePremiumResult();
            premiumResponse.premiumAmount = Math.Round((_carValue * _premiumPercentage) / 100, 0);
            premiumResponse.premiumTaxAmount = Math.Round((premiumResponse.premiumAmount * _taxPercentage) / 100, 0);
            premiumResponse.premiumTotalAmount = Math.Round((premiumResponse.premiumAmount + premiumResponse.premiumTaxAmount), 0);
            premiumResponse.premiumChargesPercentage = _premiumPercentage;
            premiumResponse.premiumTaxPercentage = _taxPercentage;
            return premiumResponse;
        }
    }
}
