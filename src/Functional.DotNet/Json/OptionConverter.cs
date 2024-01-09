using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Functional.DotNet.Json
{
    using static F;
    public class OptionConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Option<>);

        public override JsonConverter? CreateConverter
        (
           Type type,
           JsonSerializerOptions options
        )
        => Activator.CreateInstance
        (
           typeof(OptionConverterInner<>)
              .MakeGenericType(new Type[] { type.GetGenericArguments()[0] }),
           BindingFlags.Instance | BindingFlags.Public,
           binder: null,
           args: new object[] { options },
           culture: null
        ) as JsonConverter;

        private class OptionConverterInner<T> : JsonConverter<Option<T>>
        {
            private readonly JsonConverter<T> _valueConverter;
            private readonly Type _valueType;

            public override bool HandleNull => true;

            public OptionConverterInner(JsonSerializerOptions options)
            {
                // For performance, use the existing converter if available
                _valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));

                // Cache the value type
                _valueType = typeof(T);
            }

            public override Option<T> Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                // deserialize 'null' into a None
                if (reader.TokenType == JsonTokenType.Null)
                    return None;

                // deserialize non-null value into a Some
                T? t = _valueConverter != null
                   ? _valueConverter.Read(ref reader, _valueType, options)
                   : JsonSerializer.Deserialize<T>(ref reader, options);

                return Some(t ?? throw new InvalidOperationException($"'{t}' could not be deserialized into a {typeof(T)}"));
            }

            public override void Write
            (
                Utf8JsonWriter writer,
                Option<T> option,
                JsonSerializerOptions options
            )
            => option.Match
            (
               () => writer.WriteNullValue(),
               (value) => {
                   if (_valueConverter != null)
                       _valueConverter.Write(writer, value, options);
                   else JsonSerializer.Serialize(writer, value, options);
               }
            );
        }
    }
}
