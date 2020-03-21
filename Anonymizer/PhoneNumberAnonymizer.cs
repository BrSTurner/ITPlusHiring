using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymizer
{
    /// <summary>
    /// Class PhoneNumberAnonymizer.
    /// </summary>
    /// <example>
    /// Sample usages (parametrized):
    ///  +48 666 777 888 -> +48 666 777 XXX
    ///  +246 666 777 888 -> +246 666 7XX XXX
    ///  +246 666 777 888 -> +246 666 777 88*
    ///  +246 666 777 888 -> +246 xxx xxx xxx
    ///  666 777 888 -> xxx xxx xxx
    ///  +246 666 777 88 -> +246 666 777 88
    ///  666 777 88 -> 666 777 88
    /// </example>
    public class PhoneNumberAnonymizer : BaseAnonymizer
    {
        private readonly int _lastDigits;

        public PhoneNumberAnonymizer(string replacement, int lastDigits) : base(replacement)
        {
            _lastDigits = lastDigits;
        }

        public override string Anonymize(string text)
        {
            text = base.Anonymize(text);

            if (_lastDigits <= 0)
                return text;

            var phonePattern = new Regex("(\\+\\d{2,3}\\s)?\\d{3}\\s\\d{3}\\s\\d{3}"); 
            var values = phonePattern.Matches(text);

            if (values.All(x => x.Success))
            {
                for (var i = 0; i < values.Count; i++)
                {
                    var valueToBeReplaced = values[i].Value;
                    var valueLenght = valueToBeReplaced.Length;
                    var digitsLeft = _lastDigits;

                    for (var index = valueLenght-1; index > 0 && digitsLeft > 0; index--)
                    {
                        if (!Char.IsWhiteSpace(valueToBeReplaced[index])){
                            valueToBeReplaced = valueToBeReplaced.Remove(index, 1).Insert(index, _replacement);
                            digitsLeft--;
                        }
                    }

                    text = text.Replace(values[i].Value, valueToBeReplaced);
                }
            }

            return text;
        }
    }
}