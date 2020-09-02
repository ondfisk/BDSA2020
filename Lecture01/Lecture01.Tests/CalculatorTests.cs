using System;
using Xunit;

namespace Lecture01.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_given_empty_string_returns_0()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var actual = sut.Add(string.Empty);

            // Assert
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("42", 42)]
        [InlineData("0", 0)]
        [InlineData("1,41", 42)]
        [InlineData("2,40", 42)]
        [InlineData("0,42", 42)]
        [InlineData("4,38", 42)]
        [InlineData("2,4,36", 42)]
        public void Add_given_input_returns_expected(string input, int expected)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var actual = sut.Add(input);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("foo")]
        [InlineData("!!")]
        public void Add_given_invalid_input_returns_minus_1(string invalidInput)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var actual = sut.Add(invalidInput);

            // Assert
            Assert.Equal(-1, actual);
        }
    }
}
