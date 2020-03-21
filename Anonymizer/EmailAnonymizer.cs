using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anonymizer
{

	/// <summary>
	/// Class EmailAnonymizer.
	/// </summary>
	/// <example>
	/// Sample usages(parametrized):
	/// aaa@aaa.com -> ...@aaa.com
	/// aaa@aaa.aaa.com -> ...@aaa.aaa.com
	/// a-a @a_a.com -> XXX @a_a.com
	/// </example>
	public class EmailAnonymizer : BaseAnonymizer
	{
		public EmailAnonymizer(string replacement) : base(replacement) { }

		public override string Anonymize(string text)
		{
			text = base.Anonymize(text);

			var firstAndLastPattern = new Regex("[a-zA-Z0-9]");
			var pattern = new Regex("^[a-zA-Z0-9._-]+$");

			var groups = text.Split(' ');

			Parallel.ForEach(groups, group =>
			{
				if (group.Contains("@")){
					var values = group.Split('@');
					var valueToAnonymize = values[0];
					var domain = values[1].Substring(0, values[1].IndexOf('.'));

					if (pattern.IsMatch(valueToAnonymize) && pattern.IsMatch(domain) &&
						domain.ValidateFirstAndLastCharacterRegex(firstAndLastPattern) && valueToAnonymize.ValidateFirstAndLastCharacterRegex(firstAndLastPattern))
					{
						var newEmail = new StringBuilder(group).Replace(valueToAnonymize, _replacement, 0, group.IndexOf('@')).ToString();
						text = text.Replace(group, newEmail);
					}
				}
			});
			
			return text;
        }
	}
}