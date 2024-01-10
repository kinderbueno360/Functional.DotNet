using FluentAssertions;
using Functional.DotNet;

namespace Functional.DotNet.Tests
{
    public class StatelessAgentTests
    {
        //[Fact]
        //public void StatelessAgent_ShouldProcessMessage()
        //{
        //    // Arrange
        //    bool messageProcessed = false;
            
        //    var agent = Agent.Start<string>(msg => messageProcessed = true);

        //    // Act
        //    agent.Tell("test message");

        //    // Assert
        //    messageProcessed.Should().BeTrue();
        //}

        //[Fact]
        //public async Task StatelessAgent_ShouldProcessMessage_Async()
        //{
        //    // Arrange
        //    bool messageProcessed = false;
        //    var agent = Agent.Start<string>(async msg =>
        //    {
        //        await Task.Delay(10); // Simulate async work
        //        messageProcessed = msg == "test";
        //    });

        //    // Act
        //    agent.Tell("test");
        //    await Task.Delay(20); // Allow time for async processing

        //    // Assert
        //    messageProcessed.Should().BeTrue();
        //}

    }
}
