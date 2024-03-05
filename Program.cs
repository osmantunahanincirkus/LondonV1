using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using London.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; });
builder.Services.AddRouting(opt => { opt.LowercaseUrls = true; });

builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(typeof(StartupSetup).Assembly, ServiceLifetime.Transient);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();