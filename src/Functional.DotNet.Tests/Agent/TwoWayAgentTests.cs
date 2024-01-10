using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests
{
    public class TwoWayAgentTests
    {
        [Fact]
        public async Task TwoWayAgent_ShouldProcessAndReply_Synchronously()
        {
            // Arrange
            var agent = Agent.Start<int, string, string>(
                1,
                (state, msg) => (1, "Processed " + msg));

            // Act
            var reply = await agent.Tell("message");

            // Assert
            reply.Should().Be("Processed message");
            // Additional state check if applicable
        }

        //[Fact]
        //public async Task TwoWayAgent_ShouldProcessAndReply_Async()
        //{
        //    // Arrange
        //    var agent = Agent.Start<int, string, string>(
        //        "initial",
        //        async (state, msg) =>
        //        {
        //            await Task.Delay(10); // Simulate async work
        //            return (state + msg, "Processed " + msg);
        //        });

        //    // Act
        //    var reply = await agent.Tell("message");

        //    // Assert
        //    reply.Should().Be("Processed message");
        //    // Additional state check if applicable
        //}

        //[Fact]
        //public async Task TwoWayAgent_ShouldHandleErrors()
        //{
        //    // Arrange
        //    var agent = Agent.Start<int, string, string>(
        //        "initial",
        //        (state, msg) => throw new InvalidOperationException("Error processing message"));

        //    // Act
        //    var task = agent.Tell("message");

        //    // Assert
        //    await Assert.ThrowsAsync<InvalidOperationException>(() => task);
        //}
    }
}
