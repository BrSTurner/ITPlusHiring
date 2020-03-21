using System.Collections.Generic;
using Anonymizer;
using NUnit.Framework;

namespace Anonymizer.Tests
{
    [TestFixture]
    public class OfferTest
    {
        [Test]
        public void SimpleTest()
        {
            // Arrange
            var offerAnonymizer = new OfferAnonymizer();
            offerAnonymizer.AddAnonymizer(new EmailAnonymizer("REPLACED"));
            offerAnonymizer.AddAnonymizer(new SkypeUsernameAnonymizer("REPLACED"));
            offerAnonymizer.AddAnonymizer(new PhoneNumberAnonymizer("X", 2));
            var text = "Lorem ipsum a@a.com. <a href=\"skype:loremipsum?call\">call</a> +48 666 777 888";
            var replaced = "Lorem ipsum REPLACED@a.com. <a href=\"skype:REPLACED?call\">call</a> +48 666 777 8XX";

            // Act
            var actual = offerAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }
    }
}