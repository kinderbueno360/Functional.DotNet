using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Functional.DotNet.Extensions;
using Microsoft.Reactive.Testing; // Ensure this is correctly referenced


namespace Functional.DotNet.Tests
{
    public class ObservableExtTests
    {
        [Fact]
        public async Task Partition_ShouldCorrectlyPartitionValues()
        {
            // Arrange
            var source = Observable.Range(1, 5); // Observable sequence from 1 to 5
            Func<int, bool> predicate = x => x % 2 == 0; // Predicate to partition even numbers

            // Act
            var (Passed, Failed) = source.Partition(predicate);
            var passedResult = await Passed.ToList();
            var failedResult = await Failed.ToList();

            // Assert
            passedResult.Should().BeEquivalentTo(new[] { 2, 4 }); // Even numbers
            failedResult.Should().BeEquivalentTo(new[] { 1, 3, 5 }); // Odd numbers
        }

        [Fact]
        public async Task PairWithPrevious_ShouldCorrectlyPairElements()
        {
            // Arrange
            var source = Observable.Range(1, 3); // Observable sequence from 1 to 3

            // Act
            var result = await source.PairWithPrevious().ToList();

            // Assert
            result.Should().BeEquivalentTo(new[]
                {
                    (Previous: 1, Current: 2),
                    (Previous: 2, Current: 3)
                }
            );
        }
    }

}