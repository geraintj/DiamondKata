using System;
using System.Collections.Specialized;
using System.Linq;
using Xunit;

namespace DiamondKata.UnitTests
{
    public class DiamondGeneratorTests
    {
        [Fact]
        public void PrintDiamondReturnsExpectedType()
        {
            // Arrange
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond('A');

            // Assert
            Assert.IsType<StringCollection>(result);
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('M', 25)]
        [InlineData('Z', 51)]
        public void PrintDiamondReturnsCorrectNumberOfLines(char input, int expectedNumberOfLines)
        {
            // Arrange
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond(input);

            // Assert
            Assert.Equal(expectedNumberOfLines, result.Count);
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', "ABA")]
        [InlineData('C', "ABCBA")]
        [InlineData('M', "ABCDEFGHIJKLMLKJIHGFEDCBA")]
        public void PrintDiamondReturnsCorrectCharacterOnEachLine(char input, string lineLetters)
        {
            // Arrange
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond(input);

            // Assert
            var index = 0;
            foreach (var line in result)
            {
                Assert.StartsWith(lineLetters[index].ToString(), line.Trim());
                index++;
            }
        }

        [Fact]
        public void PrintDiamondReturnsCorrectlyFormattedLines()
        {
            // Arrange
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond('C');

            // Assert
            Assert.Equal("  A", result[0]);
            Assert.Equal(" B B", result[1]);
            Assert.Equal("C   C", result[2]);
            Assert.Equal(" B B", result[3]);
            Assert.Equal("  A", result[4]);
        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('b', 3)]
        [InlineData('c', 5)]
        [InlineData('m', 25)]
        [InlineData('z', 51)]
        public void PrintDiamondAllowsSmallCaseInput(char input, int expectedNumberOfLines)
        {
            // Arrange
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond(input);

            // Assert
            Assert.Equal(expectedNumberOfLines, result.Count);
        }
        
        [Theory]
        [InlineData('!')]
        [InlineData('#')]
        [InlineData('=')]
        [InlineData('@')]
        [InlineData('\\')]
        public void PrintDiamondWarnsOnInvalidCharacter(char input)
        {
            // Arrange
            var sut = new DiamondGenerator();

            // Act
            var result = sut.PrintDiamond(input);

            // Assert
            Assert.Single(result);
            Assert.Contains("invalid", result[0]);
        }
    }
}