namespace Csharp.Functional.MinimalApi.Sample.Infra.Models
{
    public sealed record JwtSettings
    {
        public string Secret { get; init; }
        public int ExpiryMinutes { get; init; }
    }
}
