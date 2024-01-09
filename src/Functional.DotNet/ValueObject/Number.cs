using Functional.DotNet.Json;
using System.Text.Json.Serialization;
using static Functional.DotNet.F;

namespace Functional.DotNet.ValueObject
{

    [JsonConverter(typeof(NumberJsonConverter))]
    public record struct Number 
    {

        public static Number Create(ulong? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(decimal? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(uint? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(int? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(Int64? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(double? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(float? value)
        {
            Number outcome = value;
            return outcome;
        }

        public static Number Create(short? value)
        {
            Number outcome = value;
            return outcome;
        }

        private Option<decimal> value;

        private Number(Option<decimal> numberValue)
        {
            value = numberValue;
        }

        public static implicit operator Number(int value) =>
            new(Some((decimal)value));

        public static implicit operator Number(decimal value) =>
            new(Some(value));

        public static implicit operator Number(uint value) =>
            new(Some((decimal)value));

        public static implicit operator Number(double value) =>
            new(Some((decimal)value));

        public static implicit operator Number(float value) =>
            new(Some((decimal)value));

        public static implicit operator Number(short value) =>
            new(Some((decimal)value));

        public static implicit operator Number(long value) =>
            new(Some((decimal)value));

        public static implicit operator Number(ulong value) =>
            new(Some((decimal)value));

        public static implicit operator Number(decimal? value) =>
            (value is null)
                ? None
                : new(Some(value.Value));

        public static implicit operator Number(int? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator Number(Int64? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator Number(ulong? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator Number(uint? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));


        public static implicit operator Number(double? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator Number(float? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));

        public static implicit operator Number(short? value) =>
            (value is null)
                ? None
                : new(Some((decimal)value.Value));


        public static Number None => new Number(F.None);


        public Option<R> Map<R>(Func<decimal, R> mapFunc) =>
            value.Map(mapFunc);


        public bool IsSome() => value.IsSome();

        public bool IsNone() => !value.IsSome();

        public Option<R> Match<R>(Func<R> None, Func<decimal, R> Some) =>
            value.Match(
                None: None,
                Some: Some);

        public Option<decimal> ToOption() => value;


        public static implicit operator decimal?(Number number) => number.GetValueAsDecimal();

        public static implicit operator decimal(Number number) => number.GetValueAsDecimal() ?? 0;

        public static implicit operator int?(Number number) => number.GetValueAsInt();

        public static implicit operator Int64?(Number number) => number.GetValueAsInt64();

        public static implicit operator int(Number number) => number.GetValueAsInt() ?? 0;

        public static implicit operator ulong?(Number number) => number.GetValueAsUlong();

        public static implicit operator ulong(Number number) => number.GetValueAsUlong() ?? 0;

        public static implicit operator uint?(Number number) => number.GetValueAsUint();

        public static implicit operator uint(Number number) => number.GetValueAsUint() ?? 0;

        public static implicit operator float?(Number number) => number.GetValueAsFloat();

        public static implicit operator float(Number number) => number.GetValueAsFloat() ?? 0;

        public static implicit operator double?(Number number) => number.GetValueAsDouble();

        public static implicit operator double(Number number) => number.GetValueAsDouble() ?? 0;

        public static implicit operator short?(Number number) => number.GetValueAsShort();

        public static implicit operator short(Number number) => number.GetValueAsShort() ?? 0;


        private ulong? GetValueAsUlong() =>
            value.Match(
                Some: (result) => (ulong?)result,
                None: () => null);

        private int? GetValueAsInt() =>
            value.Match(
                Some: (result) => (int?)result,
                None: () => null);

        private Int64? GetValueAsInt64() =>
            value.Match(
                Some: (result) => (Int64?)result,
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
            Some: val => val.ToString() ?? string.Empty,
            None: () => "0");


        public static Number operator +(Number a) => a;

        public static Number operator +(Number a, Number b)
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

        public static Number operator -(Number a, Number b)
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

        public bool Equals(Number other) =>
             other.IsNone()
                ? other.IsNone() == !value.IsSome() ? true : false
                : other.GetValueAsDecimal() == value.GetOrElse(0);

        public static bool operator ==(Number? left, int? right)
            => left.Value.GetValueAsInt() == right;
        public static bool operator !=(Number? left, int? right)
            => !(left.Value.GetValueAsInt() == right);


        public static bool operator ==(Number? left, Int64? right)
            => left.Value.GetValueAsInt() == right;
        public static bool operator !=(Number? left, Int64? right)
            => !(left.Value.GetValueAsInt64() == right);


        public static bool operator ==(Number left, int? right)
            => left.GetValueAsInt() == right;
        public static bool operator !=(Number left, int? right)
            => !(left.GetValueAsInt() == right);

        public static bool operator ==(Number left, Int64? right)
             => left.GetValueAsInt() == right;

        public static bool operator !=(Number left, Int64? right)
            => !(left.GetValueAsInt64() == right);

        public static bool operator ==(Number left, int right)
            => left.GetValueAsInt() == right;

        public static bool operator !=(Number left, int right)
            => !(left.GetValueAsInt() == right);

        public static bool operator ==(Number left, Int64 right)
            => left.GetValueAsInt() == right;

        public static bool operator !=(Number left, Int64 right)
            => !(left.GetValueAsInt64() == right);

        public static bool operator ==(Number left, double? right)
            => left.GetValueAsDouble() == right;

        public static bool operator !=(Number left, double? right)
            => !(left.GetValueAsDouble() == right);

        public static bool operator ==(Number left, decimal? right)
            => left.GetValueAsDecimal() == right;

        public static bool operator !=(Number left, decimal? right)
            => !(left.GetValueAsDecimal() == right);

        public static bool operator ==(Number left, decimal right)
    => left.GetValueAsDecimal() == right;
        public static bool operator !=(Number left, decimal right)
            => !(left.GetValueAsDecimal() == right);

        public static bool operator ==(Number left, float? right)
            => left.GetValueAsFloat() == right;

        public static bool operator !=(Number left, float? right)
            => !(left.GetValueAsFloat() == right);

        public static bool operator ==(Number left, uint? right)
            => left.GetValueAsUint() == right;

        public static bool operator !=(Number left, uint? right)
            => !(left.GetValueAsFloat() == right);

        public static bool operator ==(Number left, Number? right)
            => left.Equals(right ?? Number.None);

        public static bool operator !=(Number left, Number? right)
            => !left.Equals(right ?? Number.None);


        public static bool operator ==(Number? left, Number right)
            => left.HasValue
                ? left.Equals(right)
                : false;

        public static bool operator !=(Number? left, Number right)
            => left.HasValue
                ? !left.Equals(right)
                : true;



        // Ulong
        public static bool operator ==(Number left, ulong? right)
            => left.GetValueAsUlong() == right;
        public static bool operator !=(Number left, ulong? right)
            => !(left.GetValueAsUlong() == right);

        public static bool operator ==(Number left, ulong right)
            => left.GetValueAsUlong() == right;
        public static bool operator !=(Number left, ulong right)
            => !(left.GetValueAsUlong() == right);


        public int GetOrElse(int elseValue) => (int)value.GetOrElse(elseValue);

        public Int64 GetOrElse(Int64 elseValue) => (Int64)value.GetOrElse(elseValue);

        public decimal GetOrElse(decimal elseValue) => value.GetOrElse(elseValue);

        public double GetOrElse(double elseValue) => (double)value.GetOrElse((decimal)elseValue);

        public float GetOrElse(float elseValue) => (float)value.GetOrElse((decimal)elseValue);

        public override int GetHashCode() => value.GetOrElse(0).GetHashCode();

        public Option<T> Map<T>(Func<Number, T> convertFunc) => value.Match(
            Some: (value) => Some(convertFunc(value)),
            None: () => F.None);


        public Option<R> Bind<R>
            (Func<Number, Option<R>> f)
                => value.Match(
                    () => F.None,
                    (t) => f(t));

        public Number Match
            (Func<Number, Number> f)
                => value.Match(
                    () => Number.None,
                    (t) => f(t));


        public TypeCode GetTypeCode()
        {
            return TypeCode.Decimal;
        }
    }
}
