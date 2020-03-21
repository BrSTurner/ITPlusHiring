using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymizer
{
    public static class StringExtension
    {
        public static bool ValidateFirstAndLastCharacterRegex(this string value, Regex regex){
            return (regex.IsMatch(value[0].ToString()) && regex.IsMatch(value?[value.Length - 1].ToString()));
        }
    }
}
