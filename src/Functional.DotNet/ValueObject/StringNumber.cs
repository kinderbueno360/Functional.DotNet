using Functional.DotNet;
using Functional.DotNet.Json;
using System.Text.Json.Serialization;
using static Functional.DotNet.F;

namespace Functional.DotNet.ValueObject
{
    [JsonConverter(typeof(NumberJsonConverter))]
    public record struct StringNumber
    {
        public static StringNumber Create(string? value) =>
                    new(Some((decimal)Some(value)
                                .Map(RemoveFormatting)
                                .Map(x => x.ToDouble() / 100)
                                .Match(
                                    Some: result => result,
                                    None: () => 0)));

        public static StringNumber Create(ulong? value) => value;
        public static StringNumber Create(decimal? value) => value;
        public static StringNumber Create(uint? value) => value;
        public static StringNumber Create(int? value) => value;
        public static StringNumber Create(double? value) => value;
        public static StringNumber Create(float? value) => value;

        public static StringNumber Create(long? value) => value;

        private Option<decimal> value;

        private StringNumber(Option<decimal> numberValue)
        {
            value = numberValue.Map(x => x * 100);
        }

        public static Func<string, string> RemoveFormatting = (value) =>
              value
                  .Replace(" ", "")
                  .Replace("€", "")
                  .Replace(",", "")
                  .Replace(".", "")
                  .Trim();

        public static implicit operator StringNumber(string value) =>
            new(Some((decimal)Some(value)
                                .Map(RemoveFormatting)
                                .Map(x => x.ToDouble() / 100)
                                .Match(
                                    Some: result => result,
                                    None: () => 0)));

        public static implicit operator StringNumber(int value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(decimal value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(uint value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(double value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(float value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(short value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(long value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(ulong value) =>
            new(Some((decimal)value));

        public static implicit operator StringNumber(decimal? value) =>
            (value is null)
                ? None
                : new(Some(value.Value));

        public static implicit operator StringNumber(int? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator StringNumber(ulong? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator StringNumber(uint? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));


        public static implicit operator StringNumber(double? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator StringNumber(float? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator StringNumber(short? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator StringNumber(long? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static StringNumber None => new StringNumber(F.None);

        public static StringNumber Parse(string? value) =>
            (string.IsNullOrEmpty(value) || !decimal.TryParse(value, out var result))
                ? None
                : new StringNumber(Some(result));

        public Option<R> Map<R>(Func<decimal, R> mapFunc) =>
            value.Map(mapFunc);


        public bool IsSome() => value.IsSome();

        public bool IsNone() => !value.IsSome();

        public Option<R> Match<R>(Func<R> None, Func<decimal, R> Some) =>
            value.Match(
                None: None,
                Some: Some);

        public Option<decimal> ToOption() => value;


        public static implicit operator string(StringNumber number) => number.ToString();

        public static implicit operator decimal?(StringNumber number) => number.GetValueAsDecimal();

        public static implicit operator decimal(StringNumber number) => number.GetValueAsDecimal() ?? 0;

        public static implicit operator int?(StringNumber number) => number.GetValueAsInt();

        public static implicit operator int(StringNumber number) => number.GetValueAsInt() ?? 0;

        public static implicit operator ulong?(StringNumber number) => number.GetValueAsUlong();

        public static implicit operator ulong(StringNumber number) => number.GetValueAsUlong() ?? 0;

        public static implicit operator uint?(StringNumber number) => number.GetValueAsUint();

        public static implicit operator uint(StringNumber number) => number.GetValueAsUint() ?? 0;

        public static implicit operator float?(StringNumber number) => number.GetValueAsFloat();

        public static implicit operator float(StringNumber number) => number.GetValueAsFloat() ?? 0;

        public static implicit operator double?(StringNumber number) => number.GetValueAsDouble() / 100;

        public static implicit operator double(StringNumber number) => number.GetValueAsDouble() / 100 ?? 0;

        public static implicit operator short?(StringNumber number) => number.GetValueAsShort();

        public static implicit operator short(StringNumber number) => number.GetValueAsShort() ?? 0;


        private ulong? GetValueAsUlong() =>
            value.Match(
                Some: (result) => (ulong?)result,
                None: () => null);

        private int? GetValueAsInt() =>
            value.Match(
                Some: (result) => (int?)result,
                None: () => null);

        private uint? GetValueAsUint() =>
            value.Match(
                Some: (result) => (uint?)result,
                None: () => null);

        private decimal? GetValueAsDecimal() =>
            value.Match(
                Some: (result) => (decimal?)result,
                None: () => null);

        private short? GetValueAsShort() =>
            value.Match(
                Some: (result) => (short?)result,
                None: () => null);

        private double? GetValueAsDouble() =>
            value.Match(
                Some: (result) => (double?)result,
                None: () => null);

        public float? GetValueAsFloat() =>
            value.Match(
                Some: (result) => (float?)result,
                None: () => null);

        public override string ToString() => value.Match(
            Some: val => (val / 100).ToString() ?? string.Empty,
            None: () => "0");


        public static StringNumber operator +(StringNumber a) => a;

        public static StringNumber operator +(StringNumber a, StringNumber b)
        {
            if (a.IsNone())
                return b;

            if (b.IsNone())
                return a;

            decimal valueA = a.value.GetOrElse(0);
            decimal valueB = b.value.GetOrElse(0);
            decimal result = valueA + valueB;
            return result;
        }

        public static StringNumber operator -(StringNumber a, StringNumber b)
        {
            if (a.IsNone())
                return b;

            if (b.IsNone())
                return a;

            decimal valueA = a.value.GetOrElse(0);
            decimal valueB = b.value.GetOrElse(0);
            decimal result = valueA - valueB;
            return result;
        }

        public bool Equals(StringNumber other) =>
             other.IsNone()
                ? other.IsNone() == !value.IsSome() ? true : false
                : other.GetValueAsDecimal() == value.GetOrElse(0);

        public static bool operator ==(StringNumber? left, int? right)
            => left.Value.GetValueAsInt() == right;
        public static bool operator !=(StringNumber? left, int? right)
            => !(left.Value.GetValueAsInt() == right);


        public static bool operator ==(StringNumber left, int? right)
            => left.GetValueAsInt() == right;
        public static bool operator !=(StringNumber left, int? right)
            => !(left.GetValueAsInt() == right);

        public static bool operator ==(StringNumber left, int right)
    => left.GetValueAsInt() == right;
        public static bool operator !=(StringNumber left, int right)
            => !(left.GetValueAsInt() == right);

        public static bool operator ==(StringNumber left, double? right)
            => left.GetValueAsDouble() == right;
        public static bool operator !=(StringNumber left, double? right)
            => !(left.GetValueAsDouble() == right);


        public static bool operator ==(StringNumber left, decimal? right)
            => left.GetValueAsDecimal() == right;
        public static bool operator !=(StringNumber left, decimal? right)
            => !(left.GetValueAsDecimal() == right);

        public static bool operator ==(StringNumber left, decimal right)
    => left.GetValueAsDecimal() == right;
        public static bool operator !=(StringNumber left, decimal right)
            => !(left.GetValueAsDecimal() == right);

        public static bool operator ==(StringNumber left, float? right)
            => left.GetValueAsFloat() == right;

        public static bool operator !=(StringNumber left, float? right)
            => !(left.GetValueAsFloat() == right);

        public static bool operator ==(StringNumber left, uint? right)
            => left.GetValueAsUint() == right;

        public static bool operator !=(StringNumber left, uint? right)
            => !(left.GetValueAsFloat() == right);

        public static bool operator ==(StringNumber left, StringNumber? right)
            => left.Equals(right ?? StringNumber.None);

        public static bool operator !=(StringNumber left, StringNumber? right)
            => !left.Equals(right ?? StringNumber.None);


        public static bool operator ==(StringNumber? left, StringNumber right)
            => left.HasValue
                ? left.Equals(right)
                : false;

        public static bool operator !=(StringNumber? left, StringNumber right)
            => left.HasValue
                ? !left.Equals(right)
                : true;



        // Ulong
        public static bool operator ==(StringNumber left, ulong? right)
            => left.GetValueAsUlong() == right;
        public static bool operator !=(StringNumber left, ulong? right)
            => !(left.GetValueAsUlong() == right);

        public static bool operator ==(StringNumber left, ulong right)
            => left.GetValueAsUlong() == right;
        public static bool operator !=(StringNumber left, ulong right)
            => !(left.GetValueAsUlong() == right);


        public int GetOrElse(int elseValue) => (int)value.GetOrElse(elseValue);

        public decimal GetOrElse(decimal elseValue) => value.GetOrElse(elseValue);

        public double GetOrElse(double elseValue) => (double)value.GetOrElse((decimal)elseValue);

        public float GetOrElse(float elseValue) => (float)value.GetOrElse((decimal)elseValue);

        public override int GetHashCode() => value.GetOrElse(0).GetHashCode();

        public Option<T> Map<T>(Func<StringNumber, T> convertFunc) => value.Match(
            Some: (value) => Some(convertFunc(value)),
            None: () => F.None);


        public Option<R> Bind<R>
            (Func<StringNumber, Option<R>> f)
                => value.Match(
                    () => F.None,
                    (t) => f(t));

        public StringNumber Match
            (Func<StringNumber, StringNumber> f)
                => value.Match(
                    () => StringNumber.None,
                    (t) => f(t));

    }
}
