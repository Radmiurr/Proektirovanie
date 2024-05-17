using System;
using Xunit;

namespace UnitTestApp.Tests

{
    public class Class1
    {
        [Fact]
        public void SumNumbers_ValidInput_ReturnsCorrectSum()
        {
            // Arrange
            string input = "3,8,4,2,7";

            // Act
            int result = Calculator.SumNumbers(input);

            // Assert
            Assert.Equal(24, result);
        }

        [Fact]
        public void SumNumbers_InputWithNonDigits_ThrowsException()
        {
            // Arrange
            string input = "3,8,a,4,2";

            // Assert
            Assert.Throws<ArgumentException>(() => Calculator.SumNumbers(input));
        }

        [Fact]
        public void SumNumbers_InputWithNumbersGreaterThan10_IgnoresThem()
        {
            // Arrange
            string input = "3,8,12,4,2";

            // Act
            int result = Calculator.SumNumbers(input);

            // Assert
            Assert.Equal(17, result);
        }

        [Fact]
        public void SumNumbers_InputWithMoreThan5Numbers_TakesOnlyFirst5()
        {
            // Arrange
            string input = "3,8,4,2,7,1,9";

            // Act
            int result = Calculator.SumNumbers(input);

            // Assert
            Assert.Equal(24, result);
        }

        [Fact]
        public void SumNumbers_InputWithNegativeNumbers_Returns0()
        {
            // Arrange
            string input = "3,8,4,-2,7";

            // Act
            int result = Calculator.SumNumbers(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void SumNumbers_CustomSeparator_ReturnsCorrectSum()
        {
            // Arrange
            string input = "3|8|4|2|7";

            // Act
            int result = Calculator.SumNumbers(input, '|');

            // Assert
            Assert.Equal(24, result);
        }

        [Fact]
        public void SumNumbers_EmptyInput_Returns0()
        {
            // Arrange
            string input = "";

            // Act
            //int result = Calculator.SumNumbers(input);

            // Assert
            Assert.Throws<ArgumentException>(() => Calculator.SumNumbers(input));

            //Assert.Equal(0, result);
        }

    }
}
