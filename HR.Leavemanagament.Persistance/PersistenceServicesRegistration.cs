using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Leavemanagament.Persistance
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePerisistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagamentDBContext>
                    (options => options.UseSqlServer(configuration.GetConnectionString("LeavemanagamentConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestResposity, LeaveRequestResposity>();

            return services;
        }
    }
}
