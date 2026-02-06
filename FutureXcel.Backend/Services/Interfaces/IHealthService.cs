using FutureXcel.Backend.Shared;
using FutureXcel.Backend.Shared.Enums;


namespace FutureXcel.Backend.Services.Interfaces
{
    public interface IHealthService
    {
        Task<ApiResponse<HealthStatus>> CheckHealthAsync();
    }
}
