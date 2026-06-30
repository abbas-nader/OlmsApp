using FluentValidation;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;
using OlmsApp.Middlewares;
using OlmsApp.Repositories;
using OlmsApp.Services;
using OlmsApp.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IValidator<CreatePatientDto>, CreatePatientDtoValidator>();
builder.Services.AddTransient<IValidator<UpdatePatientDto>, UpdatePatientDtoValidator>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<AuthorizeMiddleware>();
app.MapControllers();
app.Run();

