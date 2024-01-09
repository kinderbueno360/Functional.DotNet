using Xunit;

namespace Functional.Net.Tests
{
    public static class TestUtils
    {
        public static void Fail() => Assert.True(false);
    }
}
