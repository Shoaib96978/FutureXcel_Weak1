using FutureXcel.Backend.Data;
using FutureXcel.Backend.Services.Interfaces;
using FutureXcel.Backend.Shared;
using FutureXcel.Backend.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FutureXcel.Backend.Services.Implementations
{
    public class HealthService : IHealthService
    {
        private readonly ApplicationDbContext _dbContext;
        public HealthService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse<HealthStatus>> CheckHealthAsync()
        {
            try
            {
                await _dbContext.Database.OpenConnectionAsync();
                await _dbContext.Database.CloseConnectionAsync();
                return ApiResponse<HealthStatus>.Success(HealthStatus.Healthy,"Database Reached Succesfuly !");
            }
            catch (Exception ex) 
            {
                return ApiResponse<HealthStatus>.Failure(HealthStatus.DatabaseDown,
                                                        "DataBase is not reachable ",
                                                        HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
