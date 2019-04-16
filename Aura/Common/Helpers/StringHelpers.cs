using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aura.Common.Helpers
{
    public class StringHelpers
    {
        public static string SeparateStringOnCasing(string value)
        {
            return string.Join(" ", Regex.Split(value, @"(?<!^)(?=[A-Z])"));
        }
    }
}
