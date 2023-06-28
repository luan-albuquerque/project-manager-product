using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TesteVagaDevPleno;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.implementations;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;
using TesteVagaDevPleno.Modules.ProductModule.Repository.implementations;
using TesteVagaDevPleno.Modules.UserModule.Repository.contract;
using TesteVagaDevPleno.Modules.UserModule.Repository.implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var key = Encoding.ASCII.GetBytes(Settings.Secret);


builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authorization with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
});

builder.Services.AddScoped<ProductRepository, ProductRepositoryInEntity>();
builder.Services.AddScoped<CategoryRepository, CategoryRepositoryInEntity>();
builder.Services.AddScoped<UserRepository, UserRepositoryInEntity>();


builder.Services
       .AddAuthentication(opt =>
       {
           opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(x =>
       {
           x.RequireHttpsMetadata = false;
           x.SaveToken = true;
           x.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(key),
               ValidateIssuer = false,
               ValidateAudience = false
           };
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseCors(opt => opt
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.MapControllers();

app.Run();
