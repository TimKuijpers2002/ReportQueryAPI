using MediatR;
using ReportQueryAPI.App.Interfaces;
using ReportQueryAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportQueryAPI.App.Queries.GetAllReports
{
    public  class GetAllGPReportsHandler : IRequestHandler<GetAllGPReportsQuery, IEnumerable<GPReportDTO>>
    {
        private readonly IReportQueryRepository _repository;

        public GetAllGPReportsHandler(IReportQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GPReportDTO>> Handle(GetAllGPReportsQuery request, CancellationToken cancellationToken)
        {
            return (IEnumerable<GPReportDTO>)Task.FromResult(await _repository.GetAllGPReports());
        }
    }
}
