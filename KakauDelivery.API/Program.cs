using KakauDelivery.API.Configurations;
using KakauDelivery.API.Extensions;
using KakauDelivery.API.Filters;
using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Services;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivey.Infra.KakauDeliveryContext;
using KakauDelivey.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KakauDeliveryDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<JwtService>(provider =>
    new JwtService(
        builder.Configuration["JwtSettings:SecretKey"],
        builder.Configuration["JwtSettings:Issuer"],
        int.Parse(builder.Configuration["JwtSettings:ExpiryInMinutes"])));
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "KakauDelivery API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
