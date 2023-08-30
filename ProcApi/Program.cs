using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using NLog.Web;
using ProcApi.Configurations;
using ProcApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddAutoMapper();

builder.Services.AddCustomSignalR();

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

builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCustomLocalization();

app.MapControllers();

app.UseCustomExceptionHandlerMiddleware();

app.Run();