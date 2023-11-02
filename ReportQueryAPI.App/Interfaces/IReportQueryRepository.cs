using ReportQueryAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportQueryAPI.App.Interfaces
{
    public interface IReportQueryRepository
    {
        Task<GPReportDTO> GetGPReport(Guid id);
        Task<IEnumerable<GPReportDTO>> GetAllGPReports();
    }
}
