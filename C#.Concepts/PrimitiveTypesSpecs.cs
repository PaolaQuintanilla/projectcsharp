using C_.Concepts.Helpers;

namespace C_.Concepts
{
    public class PrimitiveTypesSpecs
    {
        [Fact]
        public void Members()
        {
            int maxValue = int.MaxValue;
            int minValue = int.MinValue;
            Assert.Equal(-2147483648, minValue);
            Assert.Equal(2147483647, maxValue);

            char charLetter = 'a';
            bool isWhiteSpace = char.IsWhiteSpace(charLetter);
            bool isDigit = char.IsDigit(charLetter);
            bool isLetter = char.IsLetter(charLetter);
            bool isPuntuation = char.IsPunctuation(charLetter);
            Assert.True(!isWhiteSpace);
            Assert.True(!isDigit);
            Assert.True(isLetter);
            Assert.True(!isPuntuation);

            DateTime newDate = new DateTime(1987, 01, 23, 15,30,00);
            Assert.Equal(1987, newDate.Year);
            Assert.Equal(2025, DateTime.Now.Year);
            Assert.Equal(25, newDate.AddDays(2).Day);

        }
    }
}
