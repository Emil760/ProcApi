using FluentValidation.AspNetCore;
using ProcApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddAutoMapper();

builder.Services.AddSingnalR();

builder.Services.AddRedisCaching(builder.Configuration);

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
