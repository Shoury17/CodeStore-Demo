using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.Models
{
    public class CalculatePremiumResult
    {
        public double premiumChargesPercentage { get; set; }
        public double premiumAmount { get; set; }
        public double premiumTaxPercentage { get; set; }
        public double premiumTaxAmount { get; set; }
        public double premiumTotalAmount { get; set; }
    }
}
