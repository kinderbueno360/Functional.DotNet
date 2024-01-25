using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.ValueObject
{
    public record struct Country
    {
        private string Code { get; init; } // ISO country code, e.g., "US", "GB"

        private Country(string code)
        {
            Code = code;
        }

        public void Deconstruct(out string code) => code = Code;

        public static implicit operator Country(string code) => new Country(code);

        public static Country None => new Country(string.Empty);

        // Static methods for top 40 most popular countries
        public static Country US => new Country("US");
        public static Country Australia => new Country("AU");
        public static Country Argentina => new Country("AR");
        public static Country Brazil => new Country("BR");
        public static Country Canada => new Country("CA");
        public static Country Chile => new Country("CL");
        public static Country China => new Country("CN");
        public static Country Colombia => new Country("CO");
        public static Country Egypt => new Country("EG");
        public static Country France => new Country("FR");
        public static Country Germany => new Country("DE");
        public static Country Greece => new Country("GR");
        public static Country India => new Country("IN");
        public static Country Indonesia => new Country("ID");
        public static Country Iran => new Country("IR");
        public static Country Iraq => new Country("IQ");
        public static Country Ireland => new Country("IE");
        public static Country Israel => new Country("IL");
        public static Country Italy => new Country("IT");
        public static Country Japan => new Country("JP");
        public static Country Kenya => new Country("KE");
        public static Country Malaysia => new Country("MY");
        public static Country Mexico => new Country("MX");
        public static Country Netherlands => new Country("NL");
        public static Country New_Zealand => new Country("NZ");
        public static Country Nigeria => new Country("NG");
        public static Country North_Korea => new Country("KP");
        public static Country Norway => new Country("NO");
        public static Country Pakistan => new Country("PK");
        public static Country Peru => new Country("PE");
        public static Country Philippines => new Country("PH");
        public static Country Poland => new Country("PL");
        public static Country Portugal => new Country("PT");
        public static Country Russia => new Country("RU");
        public static Country Saudi_Arabia => new Country("SA");
        public static Country South_Africa => new Country("ZA");
        public static Country South_Korea => new Country("KR");
        public static Country Spain => new Country("ES");
        public static Country Sweden => new Country("SE");
        public static Country Switzerland => new Country("CH");
        public static Country Thailand => new Country("TH");
        public static Country Turkey => new Country("TR");
        public static Country Ukraine => new Country("UA");
        public static Country United_Arab_Emirates => new Country("AE");
        public static Country United_Kingdom => new Country("GB");
        public static Country United_States => new Country("US");
        public static Country Venezuela => new Country("VE");
        public static Country Vietnam => new Country("VN");

        public string GetCode() => Code;
    }
}
