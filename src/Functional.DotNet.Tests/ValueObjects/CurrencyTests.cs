using Functional.DotNet.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests.ValueObjects
{
    public class CurrencyTests
    {
        [Fact]
        public void Currency_CreationWithCodeAndCountry_SetsCorrectCodeAndCountry()
        {
            // Arrange
            var currencyCode = "USD";
            var countryCode = "US";

            // Act
            var currency = Currency.USD;

            // Assert
            currency.Deconstruct(out var code, out var country);
            Assert.Equal(currencyCode, code);
            Assert.Equal(countryCode, country.GetCode());
        }

        [Fact]
        public void Currency_ImplicitConversionFromTuple_CreatesCorrectCurrency()
        {
            // Arrange
            var currencyInfo = ("USD", Country.US);

            // Act
            Currency currency = currencyInfo;

            // Assert
            currency.Deconstruct(out var code, out var country);
            Assert.Equal("USD", code);
            Assert.Equal("US", country.GetCode());
        }

        [Fact]
        public void Currency_ComparisonWithAnotherCurrency_ReturnsCorrectResult()
        {
            // Arrange
            var currency1 = Currency.USD;
            var currency2 = Currency.USD;
            var currency3 = Currency.EUR;

            // Act & Assert
            Assert.Equal(currency1, currency2);
            Assert.NotEqual(currency1, currency3);
        }

        [Fact]
        public void Currency_None_ReturnsEmptyCurrency()
        {
            // Act
            var currency = Currency.None;

            // Assert
            currency.Deconstruct(out var code, out var country);
            Assert.Equal(string.Empty, code);
            Assert.Equal(string.Empty, country.GetCode());
        }

        // Additional tests for specific currencies
        [Fact]
        public void Currency_SpecificCurrency_CorrectCodeAndCountry()
        {
            // Act & Assert
            var euroCurrency = Currency.EUR;
            euroCurrency.Deconstruct(out var euroCode, out var euroCountry);
            Assert.Equal("EUR", euroCode);
            Assert.Equal("DE", euroCountry.GetCode()); // Assuming EUR is associated with Germany in your implementation

            var yenCurrency = Currency.JPY;
            yenCurrency.Deconstruct(out var yenCode, out var yenCountry);
            Assert.Equal("JPY", yenCode);
            Assert.Equal("JP", yenCountry.GetCode());
            // Add more assertions for other specific currencies as needed
        }
    }
}
