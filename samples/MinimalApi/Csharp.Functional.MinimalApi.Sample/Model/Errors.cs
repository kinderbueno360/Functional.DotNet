using Functional.DotNet;
using static Functional.DotNet.F;

namespace Csharp.Functional.MinimalApi.Sample.Model
{

    public static class Errors
    {
        public static Error CategoryNameShouldNotBeEmpty = ShouldNotBeEmpty("Category name");

        public static Error CategoryAlreadyExist = Error("This category already exist.");

        public static Error CategoryNameMinLenght => MinLenght("Category name", 2);

        public static Error ShouldNotBeEmpty(string name) => Error($"{name} should not be empty.");
        public static Error MinLenght(string name, int length) => Error($"{name} should be have at least {length} characters.");
    }
}
