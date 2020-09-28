using CodeStoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo.Interfaces
{
    public interface IPolicyTypeManager
    {
        CalculatePremiumResult Calculate(UserPremiumData _userPremiumData);
    }
}
