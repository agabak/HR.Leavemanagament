using HR.Leavemanagament.Application.Contracts.Identity;
using HR.Leavemanagament.Application.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.Leavemanagament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> 
                     Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> 
                     Register(RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }
    }
}
