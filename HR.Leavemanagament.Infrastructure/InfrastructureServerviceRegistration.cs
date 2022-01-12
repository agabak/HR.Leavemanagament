using HR.Leavemanagament.Application.Contracts.Infrastructure;
using HR.Leavemanagament.Application.Models;
using HR.Leavemanagament.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Leavemanagament.Infrastructure
{
    public static class InfrastructureServerviceRegistration
    {
        public static IServiceCollection ConfigurationInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
