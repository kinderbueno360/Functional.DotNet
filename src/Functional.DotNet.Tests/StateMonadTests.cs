using Functional.DotNet.Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests
{
    public class StateMonadTests
    {
        // Test for Select (Map)
        [Fact]
        public void IncrementState_ShouldIncrementValue()
        {
            var increment = new State<int, int>(state => (state + 1, state + 1));
            var selectIncrement = increment.Select(x => x * 2);

            var (result, state) = selectIncrement(5);

            Assert.Equal(12, result);
            Assert.Equal(6, state);
        }

        

        // Test for SelectMany (Bind/FlatMap)
        [Fact]
        public void CombineStateTransformations_ShouldAccumulateResults()
        {
            var increment = new State<int, int>(state => (state + 1, state + 1));
            var doubleIncrement = increment.SelectMany(
                firstIncrement => increment,
                (firstIncrement, secondIncrement) => firstIncrement + secondIncrement);

            var (result, state) = doubleIncrement(5);

            Assert.Equal(13, result); // 6 + 7
            Assert.Equal(7, state); // Incremented twice from 5
        }

        // Test for Select (Map) using LINQ query syntax
        [Fact]
        public void IncrementState_ShouldIncrementValue2()
        {
            var increment = new State<int, int>(state => (state + 1, state + 1));
            var selectIncrement = from value in increment
                                  select value * 2;

            var (result, state) = selectIncrement(5);

            Assert.Equal(12, result);
            Assert.Equal(6, state);
        }

        // Test for SelectMany (Bind/FlatMap) using LINQ query syntax
        [Fact]
        public void CombineStateTransformations_ShouldAccumulateResults2()
        {
            var increment = new State<int, int>(state => (state + 1, state + 1));
            var doubleIncrement = from firstIncrement in increment
                                  from secondIncrement in increment
                                  select firstIncrement + secondIncrement;

            var (result, state) = doubleIncrement(5);

            Assert.Equal(13, result); // 6 + 7
            Assert.Equal(7, state); // Incremented twice from 5
        }
    }
}
