using MediatR;
using ReportQueryAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ReportQueryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ReportQueryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FeedMessages.API").EnableRetryOnFailure()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GPReportQueryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
