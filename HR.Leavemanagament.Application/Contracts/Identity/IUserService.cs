using HR.Leavemanagament.Application.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
    }
}
