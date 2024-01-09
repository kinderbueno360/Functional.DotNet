
using Functional.DotNet.ValueObject;

namespace Csharp.Functional.MinimalApi.Sample.Infra.Models
{
    public sealed record Category
    {
        public Number Id { get; init; } = Number.None;

        public string Name { get; init; } = string.Empty;
    }



}
