using NUnit.Framework;

namespace Anonymizer.Tests
{
    [TestFixture]
    public class SkypeUsernameTest
    {
        private SkypeUsernameAnonymizer _skypeUsernameAnonymizer;

        [SetUp]
        public void Init()
        {
            _skypeUsernameAnonymizer = new SkypeUsernameAnonymizer("#");
        }

        [Test]
        public void ThatSkypeUsernameIsReplaced()
        {
            // Arrange
            var text = "Lorem ipsum <a href=\"skype:loremipsum?call\">call</a> dolor sit amet";
            var replaced = "Lorem ipsum <a href=\"skype:#?call\">call</a> dolor sit amet";

            // Act
            var actual = _skypeUsernameAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatMultipleSkypeUsernamesAreReplaced()
        {
            // Arrange
            var text = "Lorem ipsum <a href=\"skype:loremipsum?call\">call</a>, dolor sit <a href=\"skype:IPSUMLOREM?chat\">chat</a> amet";
            var replaced = "Lorem ipsum <a href=\"skype:#?call\">call</a>, dolor sit <a href=\"skype:#?chat\">chat</a> amet";

            // Act
            var actual = _skypeUsernameAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }
    }
}