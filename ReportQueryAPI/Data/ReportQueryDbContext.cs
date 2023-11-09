using Microsoft.EntityFrameworkCore;
using ReportQueryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
