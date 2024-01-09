using Csharp.Functional.MinimalApi.Sample.Api.Endpoints;
using Csharp.Functional.MinimalApi.Sample.Api.Infra;
using Csharp.Functional.MinimalApi.Sample.Endpoints;
using Csharp.Functional.MinimalApi.Sample.Infra.Models;
using Csharp.Functional.MinimalApi.Sample.Services;
using Functional.DotNet.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Bind JwtSettings
var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new NumberJsonConverter());
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowManageOrigin",
                          builder =>
                          {
                              builder.WithOrigins("https://localhost:3000", "http://localhost:3000") // and the domains that you would like to allow to access your api
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Csharp Functional Sample Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @$"JWT Authorization header using the Bearer scheme.  
                      Enter 'Bearer' [space] and then your token in the text input below.  
                      Example: 'Bearer cxjhaks3243%$%^$YGdfgfdgh'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });
});

builder.Services.AddDbContext<FunctionalSampleDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb") // Use in-memory database
);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FunctionalSampleDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<CategoryService>();

var app = builder.Build();

// Add endpoints
app
  .MapAuthEndpoints()
  .MapCategoryEndpoints();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FunctionalSampleDbContext>();
    await SeedData(dbContext);
}


app.UseCors("AllowManageOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.Run();



static async Task SeedData(FunctionalSampleDbContext dbContext)
{
    if (!dbContext.Categories.Any())
    {
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Cruciferous" },
            new Category { Id = 2, Name = "Marrow" },
            new Category { Id = 3, Name = "Root" },
            new Category { Id= 4, Name = "Allium " },

        };

        dbContext.Categories.AddRange(categories);
    }

    if (!dbContext.Users.Any())
    {
        var userManager = dbContext.GetService<UserManager<User>>();

        var users = new List<User>
        {
            new User { UserName = "user1", Email = "user1@example.com", Name = "User One", },
            new User { UserName = "user2", Email = "user2@example.com", Name = "User Two" },
        };

        foreach (var user in users)
        {
            await userManager.CreateAsync(user, "12345!");
        }
    }

    await dbContext.SaveChangesAsync();
}
