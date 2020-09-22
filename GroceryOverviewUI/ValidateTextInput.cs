using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryOverviewLibrary.Models;

namespace GroceryOverviewUI
{
    public static class ValidateTextInput
    {
        public static string ProductName(string input, List<ProductModel> products)
        {
            string errorMessage = "";
            errorMessage += GeneralChecking(input, products);
            
            if(errorMessage != "")
            {
                errorMessage = $"\"{input}\" is not a valid product name.\nPlease fix the following error(s):\n\n" + errorMessage;
            }
            return errorMessage;
        }

        public static string TagName(string input, List<TagModel> tags)
        {
            string errorMessage = "";
            errorMessage += GeneralChecking(input, tags);

            if (input.ToLower().Contains("all products"))
            {
                errorMessage += $"* \"{input}\" is a reserved tag name so it can't be added\n";
            }

            if (errorMessage != "")
            {
                errorMessage = $"\"{input}\" is not a valid tag name.\nPlease fix the following error(s):\n\n" + errorMessage;
            }

            return errorMessage;
        }

        private static string GeneralChecking<T>(string input, List<T> existingElements)
        {
            List<IInput> elements = existingElements.Cast<IInput>().ToList();

            string output = "";
            if (input.Length < 1)
            {
                output += "* The input needs to be at least 1 character";
                return output;
            }

            if (input[0] == ' ')
            {
                output += "* The input can't start with empty space\n";
            }

            if (input.Contains("  "))
            {
                output += "* The input can't have double space\n";
            }

            if(elements.FindIndex(e => e.Name.ToLower() == input.ToLower()) >= 0)
            {
                output += "* The input is already used\n";
            }

            return output;
        }
    }
}
