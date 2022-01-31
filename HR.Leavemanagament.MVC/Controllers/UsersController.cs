using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Controllers
{

    public class UsersController : Controller
    {
        private readonly IAuthService _authenticationService;
        private readonly IMapper _mapper;
        public UsersController(IAuthService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm login,string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticationService.Authentication(login.Email, login.Password);
            if (isLoggedIn) return LocalRedirect(returnUrl);

            ModelState.AddModelError("", "Log in Attemp Failed. Please try again.");

            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm register)
        {
            if(ModelState.IsValid)
            {
                var retrunUrl = Url.Content("~/");
                var isCreate = await _authenticationService.Register(_mapper.Map<RegisterUserModel>(register));
                if (isCreate) return LocalRedirect(retrunUrl);
            }

            ModelState.AddModelError("", "Registration Attempt Failed. Please try agin");

            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();

            return Redirect("~/");
        }
    }
}
