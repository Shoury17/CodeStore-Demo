using CodeStoreDemo.Enums;
using CodeStoreDemo.Factories;
using CodeStoreDemo.Interfaces;
using CodeStoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeStoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr;
            // do while loop for Run function again 
            do
            {
                // Uncomment for Calculate Car insurance premium 
                ForCarPremiumCalculate();

                // Uncomment for number of Dices roll Result
                // ForDiceResult();

                // Print statement 
                Console.WriteLine("\n");
                Console.WriteLine("------- Do you want to Run again press y ? -----------");

                // Read user input
                inputStr = Console.ReadLine();
            } while (inputStr == "y");

            // Print statement
            Console.WriteLine("Thanks");
            Console.Read();
        }

        #region For Car Premium
        static void ForCarPremiumCalculate()
        {
            // Declare variables and then initialize to zero.
            int carValue = 0, registrationYear = 0;
            EnumPolicyType policyType = EnumPolicyType.Comprehensive;

            // Display title as the Console Calculator for Car insurance premium
            Console.WriteLine("\n");
            Console.WriteLine("-------Console Calculator for Car insurance premium-------\r");

            // Ask the user to type the car value.
            Console.WriteLine("Please enter the car value between 100000 to 100000000 :");
            // Validate Car Value
            if (ValidateCarValue(Console.ReadLine(), out carValue) == false)
            {
                Console.WriteLine("Car value not valid \n");
                return;
            }

            // Ask the user to type the car registration year.
            Console.WriteLine("Please enter the car registration year between 2015 to 2020 :");
            // Validate Car registration year
            if (ValidateCarRegistrationYear(Console.ReadLine(), out registrationYear) == false)
            {
                Console.WriteLine("Car registration year not valid \n");
                return;
            }

            // Ask the user to type the policy type.
            Console.WriteLine(@"Please enter the policy type number:
1 - Comprehensive
2 - Third Party
3 - Both");
            // Validate policy type
            if (ValidatePolicyType(Console.ReadLine(), out policyType) == false)
            {
                Console.WriteLine("Policy type not valid \n");
                return;
            }

            // Call function for calculate the premium
            var response = Calculate(new UserPremiumData
            {
                value = carValue,
                year = registrationYear,
                policyType = policyType
            });

            // print statement
            Console.WriteLine("\n");
            Console.WriteLine("-----------Calculation Result-------------");

            // Print Insurance calculate result
            Console.WriteLine($@"
Car Value - {carValue}
Registration year - {registrationYear}
Policy Type - {((EnumPolicyType)policyType).ToString()}
Premium Charges Percentage - {response.premiumChargesPercentage}
Amount - {response.premiumAmount}
Tax Percentage - {response.premiumTaxPercentage}
Tax Amount - {response.premiumTaxAmount}
Total Amount - {response.premiumTotalAmount}");
        }

        /// <summary>
        /// Validate Car Value
        /// </summary>
        /// <param name="_carValue"></param>
        /// <param name="_carValueInDigit"></param>
        /// <returns></returns>
        static bool ValidateCarValue(string _carValue, out int _carValueInDigit)
        {
            _carValueInDigit = 0;
            // Check Car value is digit
            if (_carValue.All(char.IsDigit) == false)
                return false;

            _carValueInDigit = Convert.ToInt32(_carValue);

            // Check car minimum or maximum value
            if (_carValueInDigit > 100000000 || _carValueInDigit < 100000)
                return false;

            return true;
        }

        /// <summary>
        /// Validate Car registration year
        /// </summary>
        /// <param name="_registrationYear"></param>
        /// <param name="_registrationYearInDigit"></param>
        /// <returns></returns>
        static bool ValidateCarRegistrationYear(string _registrationYear, out int _registrationYearInDigit)
        {
            _registrationYearInDigit = 0;
            // Check registration year is digit
            if (_registrationYear.All(char.IsDigit) == false)
                return false;

            _registrationYearInDigit = Convert.ToInt32(_registrationYear);

            // Check registration year minimum or maximum value
            if (_registrationYearInDigit > 2020 || _registrationYearInDigit < 2015)
                return false;

            return true;
        }


        /// <summary>
        /// Validate policy type
        /// </summary>
        /// <param name="_policyTypeValue"></param>
        /// <param name="_policyType"></param>
        /// <returns></returns>
        static bool ValidatePolicyType(string _policyTypeValue, out EnumPolicyType _policyType)
        {
            _policyType = EnumPolicyType.Comprehensive;
            if (_policyTypeValue.All(char.IsDigit) == false)
                return false;

            if (Enum.IsDefined(typeof(EnumPolicyType), Convert.ToInt32(_policyTypeValue)) == false)
                return false;

            _policyType = (EnumPolicyType)Convert.ToInt32(_policyTypeValue);
            return true;
        }

        /// <summary>
        /// Calculate premium
        /// </summary>
        /// <param name="_userPremiumData"></param>
        /// <returns></returns>
        static CalculatePremiumResult Calculate(UserPremiumData _userPremiumData)
        {
            // Create policy type manager according to policy type
            IPolicyTypeManager policyTypeManager = new PolicyTypeFactory().GetPolicyTypeManager(_userPremiumData.policyType);

            // Calculate result
            return policyTypeManager.Calculate(_userPremiumData);
        }
        #endregion

        #region For Dice 
        static void ForDiceResult()
        {
            int numberOfDices = 0;
            // Ask the user how many dices you want to roll
            Console.WriteLine("Please enter the number of dices you want to roll :");
            // Get the number of dices values
            numberOfDices = Convert.ToInt32(Console.ReadLine());
            

            // Declare and initialte new dice value list 
            List<int> diceValueList = new List<int>();
            
            // Use Random class for generate random number of dice
            Random rand = new Random();

            // Loop for number of dices roll
            for (int i = 0; i < numberOfDices; i++)
            {
                // Add Dice roll value in DiceValueList
                diceValueList.Add(rand.Next(1,7));
            }

            Console.WriteLine("\n");
            // print all dices number
            Console.WriteLine($"Dices value :- {string.Join(",", diceValueList)}");
            
            // print sum of dices
            Console.WriteLine($"Total Sum :- {diceValueList.Sum()}");
        }
        #endregion
    }
}
