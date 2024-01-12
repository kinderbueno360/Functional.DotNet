using FluentAssertions;
using Functional.DotNet.Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FsCheck.ResultContainer;

namespace Functional.DotNet.Tests
{
    public class OneAmongTests
    {
        [Fact]
        public void Match_WithInt_ShouldReturnCorrectValue()
        {
            var oneAmong = new OneAmong<int, string>(10);
            var result = oneAmong.Match(
                num => num.ToString(),
                text => text
            );

            result.Should().Be("10");
        }

        [Fact]
        public void Match_WithString_ShouldReturnCorrectValue()
        {
            var oneAmong = new OneAmong<int, string>("Hello");
            var result = oneAmong.Match(
                num => num.ToString(),
                text => text
            );

            result.Should().Be("Hello");
        }

        [Fact]
        public void Map_WithInt_ShouldTransformValue()
        {
            var oneAmong = new OneAmong<int, string>(10);
            var result = oneAmong.Map(num => num * 2);

            result.Match(
                num => { num.Should().Be(20); return 0; },
                text => { text.Should().BeNull(); return 0; }
            );
        }

        [Fact]
        public void Bind_WithInt_ShouldTransformAndFlatten()
        {
            var oneAmong = new OneAmong<int, string>(5);
            var result = oneAmong.Bind(num => new OneAmong<int, string>(num * 2));

            result.Match(
             num => { num.Should().Be(10); return 0; },
                text => { text.Should().BeNull(); return 0; }
            );
        }


        [Fact]
        public void Select_WithInt_ShouldProjectValue()
        {
            var oneAmong = new OneAmong<int, string>(3);
            var result = oneAmong.Select(num => num * 3);

            result.Match(
                num => { num.Should().Be(9); return 0; },
                text => { text.Should().BeNull(); return 0; }
            );
        }

        [Fact]
        public void SelectMany_WithInt_ShouldProjectAndFlatten()
        {
            var oneAmong = new OneAmong<int, string>(2);
            var result = oneAmong.SelectMany(
                num => new OneAmong<int, string>(num * 4),
                (num, res) => res + 1);

            result.Match(
                num => { num.Should().Be(9); return 0; },
                text => { text.Should().BeNull(); return 0; }
            );
        }

        [Fact]
        public void OneAmong_WithT0_ShouldMatchCorrectly()
        {
            var oneAmong = new OneAmong<string, int, double, bool, long>("Hello");

            var result = oneAmong.Match(
                stringCase => $"String: {stringCase}",
                intCase => "Other",
                doubleCase => "Other",
                boolCase => "Other",
                longCase => "Other"
            );

            Assert.Equal("String: Hello", result);
        }

        [Fact]
        public void OneAmong_WithT1_ShouldMatchCorrectly()
        {
            var oneAmong = new OneAmong<string, int, double, bool, long>(42);

            var result = oneAmong.Match(
                stringCase => $"String: {stringCase}",
                intCase => $"Int: {intCase}",
                doubleCase => "Other",
                boolCase => "Other",
                longCase => "Other"
            );

            Assert.Equal("Int: 42", result);
        }

    }
}
