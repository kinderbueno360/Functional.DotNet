using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.ValueObject
{
    public record struct Money
    {
        private Number Amount { get; init; }
        private Currency Currency { get; init; }

        private Money(Number amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(Number amount, Currency currency) =>
            new Money(amount, currency);

        public static Money None => new Money(0, Currency.None);

        public void Deconstruct(out Number amount, out Currency currency)
        {
            amount = Amount;
            currency = Currency;
        }

        public Money Add(Money other)
        {
            ValidateCurrency(other.Currency);
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            ValidateCurrency(other.Currency);
            return new Money(Amount - other.Amount, Currency);
        }

        private void ValidateCurrency(Currency otherCurrency)
        {
            if (!Currency.Equals(otherCurrency))
                throw new InvalidOperationException("Cannot operate on amounts in different currencies.");
        }

        public decimal GetAmount() => Amount;
        public Currency GetCurrency() => Currency;

        public override string ToString() => $"{Amount} {Currency.GetCode()}";
    }
}
