using ReportQueryAPI.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportQueryAPI.App.Queries.GetAllReports
{
    public class GetAllGPReportsQuery : IRequest<IEnumerable<GPReportDTO>>
    {
    }
}
