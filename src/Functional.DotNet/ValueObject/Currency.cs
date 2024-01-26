using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.ValueObject
{
    public record struct Currency
    {
        private string Code { get; init; }
        private Country Country { get; init; }

        private Currency(string code, Country country)
        {
            Code = code;
            Country = country;
        }

        public void Deconstruct(out string code, out Country country)
        {
            code = Code;
            country = Country;
        }

        public static implicit operator Currency((string Code, Country Country) currencyInfo) =>
            new Currency(currencyInfo.Code, currencyInfo.Country);

        public static Currency None => new Currency(string.Empty, Country.None);

        public static Currency USD => new Currency("USD", Country.US);
        public static Currency EUR => new Currency("EUR", Country.Germany); // Eurozone
        public static Currency JPY => new Currency("JPY", Country.Japan);
        public static Currency GBP => new Currency("GBP", Country.United_Kingdom);
        public static Currency AUD => new Currency("AUD", Country.Australia);
        public static Currency CAD => new Currency("CAD", Country.Canada);
        public static Currency CHF => new Currency("CHF", Country.Switzerland);
        public static Currency CNY => new Currency("CNY", Country.China);
        public static Currency SEK => new Currency("SEK", Country.Sweden);
        public static Currency NZD => new Currency("NZD", Country.New_Zealand);
        public static Currency MXN => new Currency("MXN", Country.Mexico);
        public static Currency NOK => new Currency("NOK", Country.Norway);
        public static Currency KRW => new Currency("KRW", Country.South_Korea);
        public static Currency TRY => new Currency("TRY", Country.Turkey);
        public static Currency RUB => new Currency("RUB", Country.Russia);
        public static Currency INR => new Currency("INR", Country.India);
        public static Currency BRL => new Currency("BRL", Country.Brazil);
        public static Currency ZAR => new Currency("ZAR", Country.South_Africa);
        public static Currency PLN => new Currency("PLN", Country.Poland);
        public static Currency THB => new Currency("THB", Country.Thailand);
        public static Currency MYR => new Currency("MYR", Country.Malaysia);
        public static Currency IDR => new Currency("IDR", Country.Indonesia);
        public static Currency PHP => new Currency("PHP", Country.Philippines);
        public static Currency ILS => new Currency("ILS", Country.Israel);


        public string GetCode() => Code;
        public Country GetCountry() => Country;
    }

}
