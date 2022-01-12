using HR.Leavemanagament.Application.Models;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
