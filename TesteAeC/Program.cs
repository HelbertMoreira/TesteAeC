using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using TesteAeC.Data;
using TesteAeC.External;
using TesteAeC.External.Implementations;
using TesteAeC.Services;
using TesteAeC.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddDbContext<AplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiTesteAeC") ??
    throw new InvalidOperationException("String de conexão cadastrada não encontrada.")));


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.MSSqlServer(connectionString: "Data source=(localdb)\\mssqllocaldb;Initial Catalog=TesteAeC;Integrated Security=True",
        sinkOptions: new MSSqlServerSinkOptions { 
            AutoCreateSqlTable = true,
            TableName = "LogEvents" })
    .CreateLogger();

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