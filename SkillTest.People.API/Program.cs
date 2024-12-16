using FluentValidation.AspNetCore;
using SkillTest.API.Middlewares;
using SkillTest.Core;
using SkillTest.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddCore();
builder.Services.AddInfra();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string allowedHost = builder.Configuration["AllowedCors"]!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(allowedHost)
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
