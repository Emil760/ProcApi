using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProcApi.Configurations;
using ProcApi.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddAutoMapper();

builder.Services.AddCustomSignalR(builder.Configuration);

builder.Services.AddRedisCaching(builder.Configuration);

builder.Services.AddCustomAuthentication(builder.Configuration);

builder.Services.AddCustomLocalization();

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddFluentValidationAutoValidation(config => { config.DisableDataAnnotationsValidation = true; })
    .AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCustomLocalization();

app.MapControllers();

app.MapHubs();

app.Run();