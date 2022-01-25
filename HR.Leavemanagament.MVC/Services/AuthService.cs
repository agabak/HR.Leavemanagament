using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        public AuthService(IClient client, ILocalStorageService localStorageService,IMapper mapper,
                                     IHttpContextAccessor httpContextAccessor) : base(localStorageService, client)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHandler = new JwtSecurityTokenHandler();
            _mapper = mapper;
        }
        public async Task<bool> Authentication(string email, string password)
        {
            try
            {
                AuthRequest authRequest = new() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(authRequest);
                if (authenticationResponse.Token != string.Empty)
                {
                    var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorageService.SetStorageValue("token", authenticationResponse.Token);
                    return true;
                }

            } catch (Exception) { return false; }
            return false;
        }

        public async Task Logout()
        {
            _localStorageService.ClearStorage(new List<string> { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterUserModel registerUser)
        {
            var registrationRequest = _mapper.Map<RegistrationRequest>(registerUser);

            var resonse = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(resonse.UserId))
            {
                return true;
            }
            return false;
           
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
