using HR.Leavemanagament.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Contracts
{
    public  interface IAuthenticationService
    {
        Task<bool> Authentication(string email, string password);
        Task<bool> Register(RegisterUserModel registerUser);
        Task Logout();
    }
}
