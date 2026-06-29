using FluentValidation;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;
using OlmsApp.Repositories;
using OlmsApp.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IValidator<CreatePatientDto>, CreatePatientDtoValidator>();
builder.Services.AddTransient<IValidator<UpdatePatientDto>, UpdatePatientDtoValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

