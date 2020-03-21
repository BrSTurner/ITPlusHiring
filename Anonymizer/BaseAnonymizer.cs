using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymizer
{
    public class BaseAnonymizer : IAnonymizer
    {
        protected readonly string _replacement;
        public BaseAnonymizer(string replacement)
        {
           _replacement  = String.IsNullOrWhiteSpace(replacement) ? String.Empty : replacement;
        }
        public virtual string Anonymize(string text)
        {
            CheckIfTextIsValid(text);
            return new Regex("/^\\s+$/").IsMatch(text) ? String.Empty : text;
        }
        protected void CheckIfTextIsValid(string text)
        {
            if (text == null)
                throw new ArgumentNullException("The parameter \"text\" cannot be null");
        }
    }
}
