using Microsoft.EntityFrameworkCore;
using ReportQueryAPI.Models;

namespace ReportQueryAPI.Data
{
    public class ReportQueryDbContext : DbContext
    {
        public ReportQueryDbContext(DbContextOptions<ReportQueryDbContext> options) : base(options)
        {

        }
        public DbSet<GPReportDTO> GPReports => Set<GPReportDTO>();
    }
}
