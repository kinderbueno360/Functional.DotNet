using Csharp.Functional.MinimalApi.Sample.Infra.Config;
using Csharp.Functional.MinimalApi.Sample.Infra.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Csharp.Functional.MinimalApi.Sample.Api.Infra
{


    public class FunctionalSampleDbContext : IdentityDbContext<User>
    {
        public FunctionalSampleDbContext(DbContextOptions<FunctionalSampleDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .ApplyConfiguration(new CategoryConfig());

            base.OnModelCreating(builder);
            // additional configuration
        }

        public DbSet<Category>  Categories { get; set; }
    }
}
