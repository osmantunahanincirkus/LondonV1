using London.Api;
using London.Api.Models;
using London.Api.Models.Entities;
using London.Api.Services;
using London.Api.Services.Interfaces;
using London.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

public static class StartupSetup
{
    // Bu metod, hizmetlerin yapılandırılması için kullanılır.
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // IJwtService arabirimini uygulayan JwtService sınıfını ekleyin
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<IUserService, UserService>();


        services.AddDbContext<MyDBContext>
        (options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version())));

        var jwtSettings = configuration.GetSection(JwtSettings.ConfigName).Get<JwtSettings>()!;

        services.AddOptions<JwtSettings>()
            .BindConfiguration(JwtSettings.ConfigName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] { }
                }
            });
        });
    }
}