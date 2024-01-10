using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests
{
    public class StatefulAgentTests
    {
        [Fact]
        public void StatefulAgent_ShouldUpdateState_Synchronously()
        {
            // Arrange
            var agent = Agent.Start<int, string>(0, (state, msg) => state + 1);

            // Act
            agent.Tell("increment");
            agent.Tell("increment");

            // Assert
            // Note: Add a method in StatefulAgent to expose the state for testing
            // agent.GetState().Should().Be(2);
        }

        //[Fact]
        //public async Task StatefulAgent_ShouldUpdateState_Async()
        //{
        //    // Arrange
        //    var agent = Agent.Start<int, string>(0, async (state, msg) =>
        //    {
        //        await Task.Delay(10); // Simulate async work
        //        return state + 1;
        //    });

        //    // Act
        //    agent.Tell("increment");
        //    agent.Tell("increment");
        //    await Task.Delay(30); // Allow time for async processing

        //    // Assert
        //    //agent.GetState().Should().Be(2);
        //}
    }

}
