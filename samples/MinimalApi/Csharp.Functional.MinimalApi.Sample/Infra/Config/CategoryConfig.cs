using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Csharp.Functional.MinimalApi.Sample.Infra.Models;
using Functional.DotNet.ValueObject;

namespace Csharp.Functional.MinimalApi.Sample.Infra.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder
                .Property(e => e.Id)
                .HasConversion(
                    value => (int)value,
                    value => Number.Create(value));
        }
    }
}
