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
    public class ThirdPartyPolicy : IPolicyTypeManager
    {

        private static readonly IReadOnlyDictionary<int, double> insuranceChargesPercentageList = new Dictionary<int, double>() {
            { 2015 , 7.5 },
            { 2016 , 7.0 },
            { 2017 , 6.5 },
            { 2018 , 6.0 },
            { 2019 , 5.5 },
            { 2020 , 5.0 },
        };
        public CalculatePremiumResult Calculate(UserPremiumData _userPremiumData)
        {
            double chargesPercentage = insuranceChargesPercentageList.FirstOrDefault(x => x.Key == _userPremiumData.year).Value;
            return PremiumCalculation.Calculate(_userPremiumData.value, chargesPercentage, 18);
        }
    }
}
