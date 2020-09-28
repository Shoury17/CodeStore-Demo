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
    public class BothPolicy : IPolicyTypeManager
    {

        /// <summary>
        /// Insurance Changes Percentage list according to year
        /// </summary>
        private static readonly IReadOnlyDictionary<int, double> insuranceChargesPercentageList = new Dictionary<int, double>() {
            { 2015 , 11.0 },
            { 2016 , 10.0 },
            { 2017 , 9.0 },
            { 2018 , 8.0 },
            { 2019 , 7.5 },
            { 2020 , 6.0 },
        };
        public CalculatePremiumResult Calculate(UserPremiumData _userPremiumData)
        {
            // Get premium charges percentage by year
            double chargesPercentage = insuranceChargesPercentageList.FirstOrDefault(x => x.Key == _userPremiumData.year).Value;
            return PremiumCalculation.Calculate(_userPremiumData.value, chargesPercentage, 18);
        }
    }
}
