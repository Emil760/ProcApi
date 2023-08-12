using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Configurations;
using ProcApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddAutoMapper();

builder.Services.AddCustomSignalR();

builder.Services.AddRedisCaching(builder.Configuration);

builder.Services.AddCustomAuthentication();

builder.Services.AddCustomLocalization();

builder.Services.AddRepositories();

builder.Services.AddServices();

//builder.Services.AddControllers()
//    .AddFluentValidation(config =>
//    {   
//        config.RegisterValidatorsFromAssemblyContaining<Program>();
//        config.ValidatorFactory = null;
//        config.ValidatorFactoryType = null;
//        config.ValidatorOptions.MessageFormatterFactory = null;
//        config.ValidatorOptions.LanguageManager.Enabled = false;
//        config.ValidatorOptions.ErrorCodeResolver = null;
//    });

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
})
    .AddFluentValidationClientsideAdapters()
    //.AddFluentValidationRulesToSwagger()
    .AddValidatorsFromAssemblyContaining<Program>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomLocalization();

app.MapControllers();

app.UseCustomExceptionHandlerMiddleware();

app.Run();
