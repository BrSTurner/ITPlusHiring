using System.Collections.Generic;

namespace Anonymizer
{
    /// <summary>
    /// Class OfferAnonymizer.
    /// </summary>
    public class OfferAnonymizer : IAnonymizer
    {
        private IList<IAnonymizer> _anonymizers = new List<IAnonymizer>();

        public void AddAnonymizer(IAnonymizer anonymizer)
        {
            _anonymizers.Add(anonymizer);
        }

        public string Anonymize(string text)
        {
            foreach (var anonymizer in _anonymizers)
            {
                text = anonymizer.Anonymize(text);
            }

            return text;
        }
    }
}