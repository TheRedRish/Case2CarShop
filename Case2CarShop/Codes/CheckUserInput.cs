using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Case2CarShop.Codes
{
    internal static class CheckUserInput
    {
        public static bool CheckIfUserInputMatchesCriteria(string? userInput)
        {
            if (userInput == null)
            {
                return false;
            }

            bool isNumber = Int16.TryParse(userInput, out short searchNumber);
            List<string> criterias = Enum.GetNames(typeof(EnumCriteria)).ToList();
            criterias = criterias.ConvertAll(c => c.ToLower());

            if (criterias.Contains(userInput.ToLower()) || (isNumber && searchNumber <= criterias.Count && searchNumber > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Regex for May contain +45 or 0045 with - or whitespace after and then 8 digits, first cant start with 0 and spaces is allowed
        public const string regex = @"^((\+|00)?45([-]| )?)?[1-9]( ?[0-9]){7}$";
        public static bool IsPhoneNumber(string? number)
        {
            if (number != null) return Regex.IsMatch(number, regex);
            else return false;
        }
    }
}
