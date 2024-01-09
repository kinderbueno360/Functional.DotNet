using Csharp.Functional.MinimalApi.Sample.Infra.Models;
using Csharp.Functional.MinimalApi.Sample.Services;
using Functional.DotNet;
using Functional.DotNet.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Csharp.Functional.MinimalApi.Sample.Endpoints
{
    using static Csharp.Functional.MinimalApi.Sample.Extensions.ResultExt;
    public static class CategoryEndpoints
    {
        public static WebApplication MapCategoryEndpoints(this WebApplication app)
        {
            MapEndpoints(app.MapGroup("/api/v1/categories"));
            return app;
        }
        
        private static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("{id}", GetById)
                .WithName("Get category")
                .WithOpenApi();

            app.MapGet("", GetAll)
                .WithName("Get categories")
                .WithOpenApi();

            app.MapPost("", Save)
                .WithName("Save category")
                .WithOpenApi();

            app.MapPut("", Update)
                .WithName("Update category")
                .WithOpenApi();

            app.MapDelete("/{id}", Delete)
                .WithName("Delete category")
                .WithOpenApi();
        }

        public static async Task<IResult> Save([FromBody] Category category, [FromServices] CategoryService categoryService) => await
            categoryService
                .Insert(category).Map(
                    Faulted: BadRequestWithLog,
                    Completed: (result) => result.Match(
                        Invalid: (ex) => Results.BadRequest(ex),
                        Valid: (outcome) => Results.Ok(outcome)));

        public static async Task<IResult> Delete([FromServices] CategoryService categoryService, [FromRoute] int id) => await
            categoryService
                .DeleteAsync(id).Map(
                    Faulted: BadRequestWithLog,
                    Completed: (task) => task.Match(
                        Valid: Results.Ok,
                        Invalid: Results.BadRequest));

        public static async Task<IResult> Update([FromBody] Category category, [FromServices] CategoryService categoryService) => await
            categoryService
                .UpdateAsync(category).Map(
                    Faulted: BadRequestWithLog,
                    Completed: (result) => result.Match(
                        Invalid: (ex) => Results.BadRequest(ex),
                        Valid: (outcome) => Results.Ok(outcome)));

        public static async Task<IResult> GetById([FromServices] CategoryService categoryService, HttpContext httpContext, [FromRoute] int id) => await
            categoryService
                .GetById(id).Map(
                    Faulted: BadRequestWithLog,
                    Completed: (result) => result.Match(
                        None: () => Results.BadRequest(),
                        Some: (outcome) => Results.Ok(outcome)));

        public static async Task<IResult> GetAll([FromServices] CategoryService categoryService, HttpContext httpContext) => await
            categoryService
                .GetAll().Map(
                    Faulted: BadRequestWithLog,
                    Completed: (result) => Results.Ok(result));

    }
}
