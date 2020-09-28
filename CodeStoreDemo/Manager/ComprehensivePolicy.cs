using CodeStoreDemo.BusinessRules;
using CodeStoreDemo.Interfaces;
using CodeStoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.Manager
{
    public class ComprehensivePolicy : IPolicyTypeManager
    {

        private static readonly IReadOnlyDictionary<int, double> insuranceChargesPercentageList = new Dictionary<int, double>() {
            { 2015 , 4.0 },
            { 2016 , 3.5 },
            { 2017 , 3.0 },
            { 2018 , 2.5 },
            { 2019 , 2.0 },
            { 2020 , 1.5 },
        };
        public CalculatePremiumResult Calculate(UserPremiumData _userPremiumData)
        {
            double chargesPercentage = insuranceChargesPercentageList.FirstOrDefault(x => x.Key == _userPremiumData.year).Value;
            return PremiumCalculation.Calculate(_userPremiumData.value, chargesPercentage, 18);
        }
    }
}
