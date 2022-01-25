using HR.Leavemanagament.Identity.Configurations;
using HR.Leavemanagament.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.Leavemanagament.Identity
{
    public class LeaveManagamentIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public LeaveManagamentIdentityDbContext
            (DbContextOptions<LeaveManagamentIdentityDbContext> options): base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Create role first and then user and last relationship btn role and user...
        //    builder.ApplyConfiguration(new RoleConfiguration());
        //    builder.ApplyConfiguration(new UserConfiguration());
        //    builder.ApplyConfiguration(new UserRoleConfiguration());
        //}
    }
}
