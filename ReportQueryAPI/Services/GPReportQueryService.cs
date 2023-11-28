using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ReportQueryAPI;
using ReportQueryAPI.Data;

namespace ReportQueryAPI.Services
{
    public class GPReportQueryService : GPReportQueryProto.GPReportQueryProtoBase
    {
        private readonly ReportQueryDbContext _dbContext;
        public GPReportQueryService(ReportQueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ReadGPReportResponse> ReadGPReport(ReadGPReportRequest request, ServerCallContext context)
        {
            if (request.Id == string.Empty)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Resource index must be greater than 0"));
            }
            var gpreport = await _dbContext.GPReports.FirstOrDefaultAsync(gpr => gpr.Id.ToString() == request.Id);

            if (gpreport != null)
            {
                return await Task.FromResult(new ReadGPReportResponse
                {
                    Id = gpreport.Id.ToString(),
                    PatientId = gpreport.PatientId.ToString(),
                    EmployeeId = gpreport.EmployeeId.ToString(),
                    InitialCreation = gpreport.InitialCreation.ToUniversalTime().ToTimestamp(),
                    Notes = gpreport.Notes,
                });
            }

            throw new RpcException(new Status(StatusCode.NotFound, $"No gpreport with id {request.Id}"));
        }

        public override async Task<GetAllGPReportResponse> GetAllGPReport(GetAllGPReportRequest request, ServerCallContext context)
        {
            var response = new GetAllGPReportResponse();
            var gpreports = await _dbContext.GPReports.ToListAsync();

            foreach (var gpreport in gpreports)
            {
                response.GpReport.Add(new ReadGPReportResponse
                {
                    Id = gpreport.Id.ToString(),
                    PatientId = gpreport.PatientId.ToString(),
                    EmployeeId = gpreport.EmployeeId.ToString(),
                    InitialCreation = gpreport.InitialCreation.ToUniversalTime().ToTimestamp(),
                    Notes = gpreport.Notes,
                }); ;
            }

            return await Task.FromResult(response);
        }
    }
}