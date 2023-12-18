using ReportQueryAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ReportQueryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<ReportQueryDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

ApplyMigrations(app);

app.MapGrpcService<GPReportQueryService>();
app.MapGet("/", () => "health check");

app.Run();

static void ApplyMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ReportQueryDbContext>();
    db.Database.Migrate();
}
