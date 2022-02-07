using HR.Leavemanagament.Domain;
using HR.Leavemanagament.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance
{
    public class LeaveManagamentDBContext: AuditableDbContext
    {
        public LeaveManagamentDBContext(DbContextOptions<LeaveManagamentDBContext> options)
            :base(options) {}

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagamentDBContext).Assembly);
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
    }
}
