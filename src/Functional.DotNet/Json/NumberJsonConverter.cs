using Functional.DotNet.ValueObject;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Functional.DotNet.Json
{
    public class NumberJsonConverter : JsonConverter<Number>
    {
        public override Number Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return Number.None;

            if (reader.TokenType != JsonTokenType.Number)
                throw new JsonException($"Unexpected token type '{reader.TokenType}'.");

            decimal value = reader.GetDecimal();
            return Number.Create(value);
        }

        public override void Write(Utf8JsonWriter writer, Number value, JsonSerializerOptions options)
        {
            if (value == Number.None)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteNumberValue(value);
            }
        }
    }
}
