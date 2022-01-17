using HR.Leavemanagament.Application.Identity;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
