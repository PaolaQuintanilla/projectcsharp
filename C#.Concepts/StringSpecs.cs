using C_.Concepts.Helpers;

namespace C_.Concepts
{
    public class StringSpecs
    {
        [Fact]
        public void Members()
        {
            var myString = "Hello world!";
            Assert.Equal("Hello", myString.Substring(0,5));
            Assert.True(myString.Contains("Hello"));
            Assert.Equal("HELLO WORLD!", myString.ToUpper());
            Assert.Equal("hello world!", myString.ToLower());
            Assert.Equal(12, myString.Length);
            Assert.Equal("HeLLo worLd!", myString.Replace("l", "L"));
            Assert.Equal("Hello world! 22", string.Concat(myString, " ", "22"));
            string scapedString = @"C:\Documents\readme.txt";
            string scapedString2 = "C:\\Documents\\readme.txt\"Between quotes\"";

            Assert.True(bool.Parse("True"));
            Assert.Equal(2.2, double.Parse("2.2"));
            Assert.Equal(1987, DateTime.Parse("12/28/1987").Year);
        }
    }
}
