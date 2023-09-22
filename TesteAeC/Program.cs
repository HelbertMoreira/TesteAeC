using System;
using TesteAeC.Data;
using TesteAeC.External;
using TesteAeC.External.Implementations;
using TesteAeC.Services;
using TesteAeC.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddDbContext<AplicationContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAeroportoServiceExternal, AeroportoServiceExternal>();
builder.Services.AddScoped<IAeroportoServices, AeroportoServices>();
builder.Services.AddScoped<ICidadeServiceExternal, CidadeServiceExternal>();
builder.Services.AddScoped<ICidadeServices, CidadeServices>();

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