using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozivNaBroj.Helpers
{
    public static class StringHelpers
    {
        public static string TrimLeadingZeroes(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            while (input.StartsWith("0"))
            {
                if (input.Length > 1)
                    input = input.Substring(1);
                else
                    input = string.Empty;
            }

            return input;
        }
    }
}
