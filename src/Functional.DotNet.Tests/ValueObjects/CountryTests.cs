using Functional.DotNet.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests.ValueObjects
{
    public class CountryTests
    {
        [Fact]
        public void Country_CreationWithCode_SetsCorrectCode()
        {
            // Arrange
            var countryCode = "US";

            // Act
            var country = Country.US;

            // Assert
            Assert.Equal(countryCode, country.GetCode());
        }


        [Fact]
        public void Country_ImplicitConversionFromString_CreatesCorrectCountry()
        {
            // Arrange
            Country country = "US";

            // Act & Assert
            Assert.Equal("US", country.GetCode());
        }

        [Fact]
        public void Country_ComparisonWithAnotherCountry_ReturnsCorrectResult()
        {
            // Arrange
            var country1 = Country.US;
            var country2 = Country.US;
            var country3 = Country.Canada;

            // Act & Assert
            Assert.Equal(country1, country2);
            Assert.NotEqual(country1, country3);
        }

        [Fact]
        public void Country_None_ReturnsEmptyCountry()
        {
            // Act
            var country = Country.None;

            // Assert
            Assert.Equal(string.Empty, country.GetCode());
        }

        // Additional tests for specific countries
        [Fact]
        public void Country_SpecificCountry_CorrectCode()
        {
            // Act & Assert
            Assert.Equal("GB", Country.United_Kingdom.GetCode());
            Assert.Equal("JP", Country.Japan.GetCode());
            // Add more assertions for other specific countries as needed
        }
    }
}
