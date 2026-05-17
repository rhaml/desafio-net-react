using DesafioApi.Configurations;
using DesafioApi.Context;
using DesafioApi.Mappers;
using DesafioApi.Models;
using DesafioApi.Repository;
using DesafioApi.Repository.Interfaces;
using DesafioApi.Services;
using DesafioApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using SecureIdentity.Password;
using System.Reflection.Metadata;
using System.Text;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseInMemoryDatabase("StudentDb"));

        builder.Services.AddScoped<IStudentRepository, StudentRepository>();

        builder.Services.AddScoped<IStudentService, StudentService>();

        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddAutoMapper(typeof(MapperProfile));

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTAuthAuthentication", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Digite: Bearer {seu token}"
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
            });
        });

        var key = Encoding.ASCII.GetBytes(JwtSettings.JwtKey);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false
            };
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(); // Habilita o JSON endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
            }); // Habilita a interface gráfica
        }

        app.UseRouting();
        app.UseCors("AllowAll");
        app.UseAuthentication(); // Must come before UseAuthorization
        app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/", () => Results.Redirect("/swagger"));


        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider
                .GetRequiredService<AppDbContext>();

            // Verifica se já existe usuário
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "10000.doWNIQ7LcupS4iuoElv2pg==.qjWuEnwIaNt6l1FGVbhA2ofQVcx0SxaNJukNjFsqbVc="
                });

                context.SaveChanges();
            }


        }
        app.Run();
    }
}