using Xunit;

namespace Functional.Net.Tests
{
    internal static class Assertions
    {
        public static void Succeed() {; }
        public static void Fail() => Assert.True(false);
    }
}
