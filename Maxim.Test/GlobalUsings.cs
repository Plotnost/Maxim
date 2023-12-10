using NUnit.Framework;

namespace Maxim.Test
{
    [TestFixture]
    public class StringHandlerTests
    {
        [TestCase("abcde", true)]
        [TestCase("12345", false)]
        [TestCase("abc@de", false)]
        [TestCase("abCde", false)]
        public void CheckString_Validations(string inputStr, bool expectedResult)
        {
            // Arrange
            var stringHandler = new StringHandler(inputStr);

            // Act
            bool result = stringHandler.CheckString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("abcde", "Самая длинная подстрока, которая начинается и заканчивается на гласную букву: abcde")]
        [TestCase("bcd", "В строке нет гласных")]
        [TestCase("ghdtyr", "Самая длинная подстрока, которая начинается и заканчивается на гласную букву: y")]
        public void SubstringSerching_Validations(string inputStr, string expectedResult)
        {
            // Arrange
            var stringHandler = new StringHandler(inputStr);

            // Act
            string result = stringHandler.SubstringSerching();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("abcder", "cbared")]
        [TestCase("ghdtyr", "dhgryt")]
        public void Handling_LengthIsEven_ReturnsReversedString(string inputStr, string expectedResult)
        {
            // Arrange
            var stringHandler = new StringHandler(inputStr);

            // Act
            string result = stringHandler.Handling();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("abcde", "edcbaabcde")]
        [TestCase("abc", "cbaabc")]
        public void Handling_LengthIsOdd_ReturnsConcatenatedReversedString(string inputStr, string expectedResult)
        {
            // Arrange
            var stringHandler = new StringHandler(inputStr);

            // Act
            string result = stringHandler.Handling();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
    
    [TestFixture]
    public class CharCouterTests
    {
        [TestCase("abcde")]
        [TestCase("aaabbbccc")]
        [TestCase("aAbBcC")]
        [TestCase("")]
        public void CountChar_ValidString_ReturnsCorrectCounts(string inputStr)
        {
            // Arrange
            var charCounter = new CharCouter(inputStr);

            // Act
            charCounter.CountChar();
            Dictionary<char, int> charCounts = charCounter.GetCount();

            // Assert
            Assert.IsNotNull(charCounts);

            foreach (var c in inputStr)
            {
                int expectedCount = inputStr.Split(c).Length - 1;
                Assert.AreEqual(expectedCount, charCounts[c]);

            }
        }
    }
    
    
}
