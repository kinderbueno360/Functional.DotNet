using Csharp.Functional.MinimalApi.Sample.Api.Infra;
using Csharp.Functional.MinimalApi.Sample.Infra.Models;
using Csharp.Functional.MinimalApi.Sample.Model;
using Functional.DotNet;
using Functional.DotNet.ValueObject;
using Microsoft.EntityFrameworkCore;
using static Functional.DotNet.F;

namespace Csharp.Functional.MinimalApi.Sample.Services
{

    public sealed class CategoryService
    {
        private readonly FunctionalSampleDbContext dbContext;

        public CategoryService(FunctionalSampleDbContext dbContext) =>
            (this.dbContext) = (dbContext);

        public async Task<Validation<Category>> Insert(Category category) =>
            await Valid(category)
                    .Bind(ValidateEmptyName)
                    .Bind(ValidateNameLength)
                    .Bind(CheckIfCategoryAlreadyExist)
                    .TraverseBind(Save);

        public async Task<Option<Category>> GetById(Number categoryId) =>
                await dbContext
                            .Categories
                            .Where(x => x.Id == categoryId)
                            .FirstOrDefaultAsync();

        public async Task<Option<Category>> GetByName(string name) =>
                await dbContext
                            .Categories
                            .Where(x => x.Name == name)
                            .FirstOrDefaultAsync();


        public async Task<IEnumerable<Category>> GetAll() =>
            await dbContext
                        .Categories
                        .ToListAsync();

        public async Task<Validation<Category>> DeleteAsync(Number categoryId) =>
            dbContext.Categories
                .Where(x=>x.Id == categoryId)
                .FirstOrDefault()
                .AsOption() //Transform to Option, I n case of Null it will be none and won't pass by map and after ToValidation will convert Nono to Error.
                .Match(  // Map just passe if the Option is not none
                    Some: Delete!,
                    None: () => Error("This category does not exist."));

        public async Task<Validation<Category>> UpdateAsync(Category category) =>
            await Valid(category)
                    .Bind(ValidateEmptyName)
                    .Bind(ValidateNameLength)
                    .Bind(CheckIfCategoryAlreadyExist)
                    .TraverseBind(Update);


        private Validation<Category> Delete(Category category)
        {
            dbContext.Remove(category);
            dbContext.SaveChanges();
            return category;
        }

        
        private async Task<Validation<Category>> Update(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        private static Validation<Category> ValidateEmptyName(Category category)
            => !string.IsNullOrEmpty(category.Name)
            ? category
            : Errors.CategoryNameShouldNotBeEmpty;

        private static Validation<Category> ValidateNameLength(Category category)
            => category.Name.Length > 2
            ? category
            : Errors.CategoryNameMinLenght;


        private Validation<Category> CheckIfCategoryAlreadyExist(Category category) =>
             dbContext.Categories.Where(x => x.Name == category.Name).FirstOrDefault()
                        .AsOption()
                        .Match(
                            Some: (result) => Errors.CategoryAlreadyExist,
                            None: () => Valid(category))!;

        private async Task<Validation<Category>> Save(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

    }
}
