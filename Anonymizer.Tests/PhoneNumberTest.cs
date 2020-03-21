using NUnit.Framework;

namespace Anonymizer.Tests
{
    [TestFixture]
    public class PhoneNumberTest
    {
        [Test]
        public void ThatTextWithoutPhoneNumberIsNotReplaced()
        {
            // Arrange
            var replacement = "X";
            var lastDigits = 3;
            var text = "Lorem ipsum";
            var replaced = "Lorem ipsum";
            var phoneNumberAnonymizer = new PhoneNumberAnonymizer(replacement, lastDigits);

            // Act
            var actual = phoneNumberAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatTextWithPhoneNumberIsReplacedWhenGivenDigitsAreSet()
        {
            // Arrange
            var replacement = "X";
            var lastDigits = 3;
            var text = "Lorem ipsum +48 666 666 666 dolor sit amet";
            var replaced = "Lorem ipsum +48 666 666 XXX dolor sit amet";
            var phoneNumberAnonymizer = new PhoneNumberAnonymizer(replacement, lastDigits);

            // Act
            var actual = phoneNumberAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatTextWithPhoneNumberIsNotReplacedWhenNoDigitsSet()
        {
            // Arrange
            var replacement = "X";
            var lastDigits = 0;
            var text = "Lorem ipsum +48 666 666 666 dolor sit amet";
            var replaced = "Lorem ipsum +48 666 666 666 dolor sit amet";
            var phoneNumberAnonymizer = new PhoneNumberAnonymizer(replacement, lastDigits);

            // Act
            var actual = phoneNumberAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatTextWithMultiplePhoneNumbersIsReplaced2()
        {
            // Arrange
            var replacement = "X";
            var lastDigits = 3;
            var text = "Lorem ipsum +48 666 666 666, +48 777 777 777 dolor sit 888 888 888 amet";
            var replaced = "Lorem ipsum +48 666 666 XXX, +48 777 777 XXX dolor sit 888 888 XXX amet";
            var phoneNumberAnonymizer = new PhoneNumberAnonymizer(replacement, lastDigits);

            // Act
            var actual = phoneNumberAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

        [Test]
        public void ThatTextWithMultiplePhoneNumbersIsReplaced()
        {
            // Arrange
            var replacement = "X";
            var lastDigits = 4;
            var text = "Lorem ipsum +223 666 666 666, +48 777 777 777 dolor sit 888 888 888 amet";
            var replaced = "Lorem ipsum +223 666 66X XXX, +48 777 77X XXX dolor sit 888 88X XXX amet";
            var phoneNumberAnonymizer = new PhoneNumberAnonymizer(replacement, lastDigits);

            // Act
            var actual = phoneNumberAnonymizer.Anonymize(text);

            // Assert
            Assert.AreEqual(actual, replaced);
        }

    }
}