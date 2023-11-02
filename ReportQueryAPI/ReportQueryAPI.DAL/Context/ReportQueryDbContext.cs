using Microsoft.EntityFrameworkCore;
using ReportQueryAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportQueryAPI.DAL.Context
{
    public class ReportQueryDbContext : DbContext
    {
        public ReportQueryDbContext(DbContextOptions<ReportQueryDbContext> options) : base(options)
        {

        }
        public DbSet<GPReportDTO> GPReports => Set<GPReportDTO>();
        public DbSet<ReportDTO> Reports => Set<ReportDTO>();
    }
}
