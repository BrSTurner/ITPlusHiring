namespace Anonymizer
{
    /// <summary>
    /// Interface Anonymizer
    /// </summary>
    public interface IAnonymizer
    {
        /// <summary>
        /// The Anonymize method.
        /// </summary>
        /// <param name="text">input string</param>
        /// <returns>result</returns>
        string Anonymize(string text);
    }
}