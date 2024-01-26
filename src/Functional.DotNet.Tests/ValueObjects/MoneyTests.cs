using Functional.DotNet.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests.ValueObjects
{
    public class MoneyTests
    {
        [Fact]
        public void Money_CreationWithAmountAndCurrency_SetsCorrectAmountAndCurrency()
        {
            // Arrange
            var amount = 100m;
            var currency = Currency.USD;

            // Act
            var money = Money.Create(amount, currency);

            // Assert
            Assert.Equal(amount, money.GetAmount());
            Assert.Equal(currency, money.GetCurrency());
        }

        [Fact]
        public void Money_AdditionWithSameCurrency_ReturnsCorrectTotal()
        {
            // Arrange
            var money1 = Money.Create(100m, Currency.USD);
            var money2 = Money.Create(50m, Currency.USD);

            // Act
            var total = money1.Add(money2);

            // Assert
            Assert.Equal(150m, total.GetAmount());
            Assert.Equal(Currency.USD, total.GetCurrency());
        }

        [Fact]
        public void Money_SubtractionWithSameCurrency_ReturnsCorrectAmount()
        {
            // Arrange
            var money1 = Money.Create(100m, Currency.USD);
            var money2 = Money.Create(30m, Currency.USD);

            // Act
            var result = money1.Subtract(money2);

            // Assert
            Assert.Equal(70m, result.GetAmount());
            Assert.Equal(Currency.USD, result.GetCurrency());
        }

        [Fact]
        public void Money_OperationWithDifferentCurrencies_ThrowsInvalidOperationException()
        {
            // Arrange
            var money1 = Money.Create(100m, Currency.USD);
            var money2 = Money.Create(100m, Currency.EUR);

            // Assert
            Assert.Throws<InvalidOperationException>(() => money1.Add(money2));
            Assert.Throws<InvalidOperationException>(() => money1.Subtract(money2));
        }

        [Fact]
        public void Money_Deconstruction_DeconstructsToCorrectAmountAndCurrency()
        {
            // Arrange
            var money = Money.Create(100m, Currency.USD);

            // Act
            var (amount, currency) = money;

            // Assert

            Assert.Equal(Currency.USD, currency);
        }

        [Fact]
        public void Money_None_ReturnsEmptyMoney()
        {
            // Act
            var money = Money.None;

            // Assert
            Assert.Equal(0m, money.GetAmount());
            Assert.Equal(Currency.None, money.GetCurrency());
        }

        // Additional tests for specific scenarios can be added as needed
    }
}
