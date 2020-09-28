using CodeStoreDemo.Enums;
using CodeStoreDemo.Interfaces;
using CodeStoreDemo.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.Factories
{
    public class PolicyTypeFactory
    {
        /// <summary>
        /// Factory which return policy Type manager
        /// </summary>
        /// <returns></returns>

        public IPolicyTypeManager GetPolicyTypeManager(EnumPolicyType policyType)
        {
            IPolicyTypeManager policyTypeManager = null;
            switch (policyType)
            {
                case EnumPolicyType.Comprehensive: policyTypeManager = new ComprehensivePolicy(); break;
                case EnumPolicyType.ThirdParty: policyTypeManager = new ThirdPartyPolicy(); break;
                case EnumPolicyType.Both: policyTypeManager = new BothPolicy(); break;
            }
            return policyTypeManager;
        }
    }
}
