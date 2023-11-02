using ReportQueryAPI.App.Interfaces;
using ReportQueryAPI.DAL.Context;
using ReportQueryAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportQueryAPI.DAL.Repositories
{
    public class ReportQueryRepository : IReportQueryRepository
    {
        private readonly ReportQueryDbContext _dbContext;

        public ReportQueryRepository(ReportQueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<GPReportDTO>> GetAllGPReports()
        {
            throw new NotImplementedException();
        }

        public Task<GPReportDTO> GetGPReport(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
