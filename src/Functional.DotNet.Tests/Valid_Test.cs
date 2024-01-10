
using FluentAssertions;
using Functional.DotNet;
using System;
using System.Linq;
using Xunit;
using static Functional.DotNet.F;

namespace Functional.Net.Tests
{
    public class Valid_Test
    {
        Validation<int> Invalid(string m = "Some error") => new Error(m);

        Func<int, int, int> add = (a, b) => a + b;
        Func<int, int, int> Multiply = (i, j) => i * j;

        private readonly Func<int, int, int, int> add3Integers =
           (a, b, c) => a + b + c;
        private readonly Func<int, int, int, int, int> add4Integers =
           (a, b, c, d) => a + b + c + d;
        private readonly Func<int, int, int, int, int, int> add5Integers =
           (a, b, c, d, e) => a + b + c + d + e;
        private readonly Func<int, int, int, int, int, int, int> add6Integers =
           (a, b, c, d, e, f) => a + b + c + d + e + f;
        private readonly Func<int, int, int, int, int, int, int, int> add7Integers =
           (a, b, c, d, e, f, g) => a + b + c + d + e + f + g;
        private readonly Func<int, int, int, int, int, int, int, int, int> add8Integers =
           (a, b, c, d, e, f, g, h) => a + b + c + d + e + f + g + h;
        private readonly Func<int, int, int, int, int, int, int, int, int, int> add9Integers =
           (a, b, c, d, e, f, g, h, i) => a + b + c + d + e + f + g + h + i;

        Func<string, Validation<int>> parseInt =>
           s => Int.Parse(s).Match(
              None: () => new Error($"{s} is not an int"),
              Some: (i) => Valid(i));

        // test that errors are accumulated

        [Fact]
        public void ItTracksErrors() => Assert.Equal(
           actual: Valid(add)
               .Apply(parseInt("4"))
               .Apply(parseInt("x")),
           expected: Invalid("x is not an int")
        );



        [Fact]
        public void TraversableA_HappyPath() => Assert.Equal(
           actual: Range(1, 4).Map(i => i.ToString())
              .Traverse(parseInt)
              .Map(list => list.Sum()),
           expected: Valid(10)
        );



        [Fact]
        public void MapAndApplySomeArg_ReturnsSome() => Assert.Equal(
           actual: Valid(3)
                    .Map(Multiply)
                    .Apply(Valid(4)),
           expected: Valid(12)
        );

        [Fact]
        public void MapAndApplyNoneArg_ReturnsNone()
        {
            var opt = Valid(3)
                .Map(Multiply)
                .Apply(Invalid());

            var opt2 = (Invalid())
                .Map(Multiply)
                .Apply(Valid(4));

            Assert.Equal(Invalid(), opt);
            Assert.Equal(Invalid(), opt2);
        }

        [Fact]
        public void ApplySomeArgs()
        {
            var opt = Valid(add)
                .Apply(Valid(3))
                .Apply(Valid(4));

            Assert.Equal(Valid(7), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_3_args()
        {
            var opt = Valid(add3Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3));

            Assert.Equal(Valid(6), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_4_args()
        {
            var opt = Valid(add4Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4));

            Assert.Equal(Valid(10), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_5_args()
        {
            var opt = Valid(add5Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4))
               .Apply(Valid(5));

            Assert.Equal(Valid(15), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_6_args()
        {
            var opt = Valid(add6Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4))
               .Apply(Valid(5))
               .Apply(Valid(6));

            Assert.Equal(Valid(21), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_7_args()
        {
            var opt = Valid(add7Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4))
               .Apply(Valid(5))
               .Apply(Valid(6))
               .Apply(Valid(7));

            Assert.Equal(Valid(28), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_8_args()
        {
            var opt = Valid(add8Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4))
               .Apply(Valid(5))
               .Apply(Valid(6))
               .Apply(Valid(7))
               .Apply(Valid(8));

            Assert.Equal(Valid(36), opt);
        }

        [Fact]
        public void ApplySomeArgs_to_function_requiring_9_args()
        {
            var opt = Valid(add9Integers)
               .Apply(Valid(1))
               .Apply(Valid(2))
               .Apply(Valid(3))
               .Apply(Valid(4))
               .Apply(Valid(5))
               .Apply(Valid(6))
               .Apply(Valid(7))
               .Apply(Valid(8))
               .Apply(Valid(9));

            Assert.Equal(Valid(45), opt);
        }

        [Fact]
        public void ApplyNoneArgs()
        {
            var opt = Valid(add)
                .Apply(Invalid())
                .Apply(Valid(4));

            Assert.Equal(Invalid(), opt);
        }

        [Fact]
        public void ApplicativeLawHolds()
        {
            var first = Valid(add)
                .Apply(Valid(3))
                .Apply(Valid(4));

            var second = Valid(3)
                .Map(add)
                .Apply(Valid(4));

            Assert.Equal(first, second);
        }

        [Fact]
        public void Valid_ShouldCreateValidValidation()
        {
            var validValue = F.Valid(42);

            validValue.IsValid.Should().BeTrue();
            validValue.Match(
                Invalid: errors => errors.Should().BeEmpty(),
                Valid: value => value.Should().Be(42));
        }

        [Fact]
        public void Invalid_ShouldCreateInvalidValidation()
        {
            var errors = new List<Error> { new Error("Test error") };
            var invalidValue = F.Invalid<int>(errors);

            invalidValue.IsValid.Should().BeFalse();
            invalidValue.Match(
                Invalid: errs => errs.Should().ContainSingle().Which.Message.Should().Be("Test error"),
                Valid: _ => Assert.True(false, "Should not be valid"));
        }

        [Fact]
        public void Map_ShouldTransformValidValue()
        {
            var validValue = F.Valid(42);
            var mappedValue = validValue.Map(v => v.ToString());

            mappedValue.IsValid.Should().BeTrue();
            mappedValue.Match(
                Invalid: _ => Assert.True(false, "Should not be invalid"),
                Valid: v => v.Should().Be("42"));
        }

        [Fact]
        public void Map_ShouldNotTransformInvalidValue()
        {
            var invalidValue = F.Invalid<int>(new Error("Test error"));
            var mappedValue = invalidValue.Map(v => v.ToString());

            mappedValue.IsValid.Should().BeFalse();
            mappedValue.Match(
                Invalid: errs => errs.Should().ContainSingle().Which.Message.Should().Be("Test error"),
                Valid: _ => Assert.True(false, "Should not be valid"));
        }

        [Fact]
        public void Bind_ShouldTransformValidValue()
        {
            var validValue = F.Valid(5);
            var boundValue = validValue.Bind(v => F.Valid(v * 2));

            boundValue.IsValid.Should().BeTrue();
            boundValue.Match(
                Invalid: _ => Assert.True(false, "Should not be invalid"),
                Valid: v => v.Should().Be(10));
        }

        [Fact]
        public void Bind_ShouldNotTransformInvalidValue()
        {
            var invalidValue = F.Invalid<int>(new Error("Error"));
            var boundValue = invalidValue.Bind(v => F.Valid(v * 2));

            boundValue.IsValid.Should().BeFalse();
            boundValue.Match(
                Invalid: errs => errs.Should().ContainSingle().Which.Message.Should().Be("Error"),
                Valid: _ => Assert.True(false, "Should not be valid"));
        }

        [Fact]
        public void Apply_ShouldApplyFunctionToValidValue()
        {
            var validFunction = F.Valid<Func<int, int>>(x => x * 2);
            var validValue = F.Valid(3);
            var appliedValue = validFunction.Apply(validValue);

            appliedValue.IsValid.Should().BeTrue();
            appliedValue.Match(
                Invalid: _ => Assert.True(false, "Should not be invalid"),
                Valid: v => v.Should().Be(6));
        }

        [Fact]
        public void Apply_ShouldNotApplyFunctionToInvalidValue()
        {
            var validFunction = F.Valid<Func<int, int>>(x => x * 2);
            var invalidValue = F.Invalid<int>(new Error("Error"));
            var appliedValue = validFunction.Apply(invalidValue);

            appliedValue.IsValid.Should().BeFalse();
            appliedValue.Match(
                Invalid: errs => errs.Should().ContainSingle().Which.Message.Should().Be("Error"),
                Valid: _ => Assert.True(false, "Should not be valid"));
        }
    }
}
