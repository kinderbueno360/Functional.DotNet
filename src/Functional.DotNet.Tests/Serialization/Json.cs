using Functional.DotNet;
using Functional.DotNet.Json;
using System.Text.Json;


namespace Functional.Net.Tests.Serialization
{
    using static F;

    public class Json
    {
        record Person(string FirstName, Option<string> MiddleName, string Lastname);

        private readonly JsonSerializerOptions ops = new()
        {
            Converters = { new OptionConverter() }
        };

        [Fact]
        public void WhenJsonIsNull_ThenCSharpIsNone()
        {
            var json = @"{""FirstName"":""Virginia"",
            ""MiddleName"":null, ""LastName"":""Woolf""}";
            var deserialized = JsonSerializer.Deserialize<Person>(json, ops);

            Assert.Equal(None, deserialized.MiddleName);
        }

        [Fact]
        public void WhenJsonIsNotNull_ThenCSharpIsSome()
        {
            var json = @"{""FirstName"":""Edgar"",
            ""MiddleName"":""Allan"", ""LastName"":""Poe""}";
            var deserialized = JsonSerializer.Deserialize<Person>(json, ops);

            Assert.Equal(Some("Allan"), deserialized.MiddleName);
        }
    }
}
