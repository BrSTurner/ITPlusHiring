using NUnit.Framework;

namespace Anonymizer.Tests
{
    [TestFixture]
    public class EmailTests
    {
        private EmailAnonymizer _emailAnonymizer;

        [SetUp]
        public void Init()
        {
            _emailAnonymizer = new EmailAnonymizer("...");
        }

        [Test]
        public void ThatTextWithoutEmailIsntReplaced()
        {
            // arrange
            var text = "Lorem ipsum";
            var replaced = "Lorem ipsum";
            
            // act
            var actual = _emailAnonymizer.Anonymize(text);
            
            // assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatEmailIsReplaced()
        {
            // arrange
            var text = "Lorem ipsum a@a.com dolor sit amet";
            var replaced = "Lorem ipsum ...@a.com dolor sit amet";

            // act
            var actual = _emailAnonymizer.Anonymize(text);

            // assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatAtOnlyIsntReplaced()
        {
            // arrange
            var text = "Lorem ipsum --@--.--";
            var replaced = "Lorem ipsum --@--.--";

            // act
            var actual = _emailAnonymizer.Anonymize(text);

            // assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatMultipleEmailsAreReplaced()
        {
            // arrange
            var text = "Lorem ipsum ...@a.com, bb12@bb12.com dolor sit abc-abc@abc.edu.co.uk amet";
            var replaced = "Lorem ipsum ...@a.com, ...@bb12.com dolor sit ...@abc.edu.co.uk amet";

            // act
            var actual = _emailAnonymizer.Anonymize(text);

            // assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatMultipleEmailsAreReplaced2()
        {
            // arrange
            var text = "Lorem ipsum a@a.com. bb12@bb12.com dolor sit ABC-ABC@abc.edu.co.uk amet";
            var replaced = "Lorem ipsum ...@a.com. ...@bb12.com dolor sit ...@abc.edu.co.uk amet";

            // act
            var actual = _emailAnonymizer.Anonymize(text);

            // assert
            Assert.AreEqual(actual, replaced);
        }
    }
}