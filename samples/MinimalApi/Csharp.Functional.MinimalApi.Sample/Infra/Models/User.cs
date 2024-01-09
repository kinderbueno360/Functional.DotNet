using Microsoft.AspNetCore.Identity;

namespace Csharp.Functional.MinimalApi.Sample.Infra.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
