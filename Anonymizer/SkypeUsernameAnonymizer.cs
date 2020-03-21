using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymizer
{
    /// <summary>
    /// Class SkypeUsernameAnonymizer.
    /// </summary>
    /// <example>
    ///  Sample usages (parametrized):
    ///  skype:john.doe -> skype:XXX
    ///  <a href ="skype:john.doe?call">call</a> -> < a href="skype:ZZZ?call">call</a>
    /// </example>
    public class SkypeUsernameAnonymizer : BaseAnonymizer
    {
        public SkypeUsernameAnonymizer(string replacement) : base(replacement){ }
        public override string Anonymize(string text) => Regex.Replace(base.Anonymize(text), "(?<=:)([a-zA-Z0-9].*?)(?=\\?)", _replacement);
        
    }
}