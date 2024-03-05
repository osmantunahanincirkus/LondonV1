using London.Api.Models;
using London.Api.Services;
using London.Api.Services.Interfaces;
using London.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

public static class StartupSetup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBookService, BookService>();

        services.AddDbContextPool<MyDBContext>
        (options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version())));

        services.AddOptions<JwtSettings>()
            .BindConfiguration(JwtSettings.ConfigName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        var jwtSettings = configuration.GetSection(JwtSettings.ConfigName).Get<JwtSettings>()!;

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
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "London", Version = "V1" });
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