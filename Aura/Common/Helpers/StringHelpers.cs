using Force.DeepCloner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aura.Common.Helpers
{
    public class StringHelpers
    {
        public static string SeparateStringOnCasing(string value)
        {
            var result = value;
            var regex = new Regex("[A-Z]");
            var matches = regex.Matches(value);

            foreach (Match match in matches)
            {
                result = match.Result($" {match.Value}");
            }

            return result;
        }
    }
}
