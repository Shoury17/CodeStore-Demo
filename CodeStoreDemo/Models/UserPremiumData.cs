using CodeStoreDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.Models
{
    public class UserPremiumData
    {
        public int value { get; set; }
        public int year { get; set; }
        public EnumPolicyType policyType { get; set; }
    }
}
