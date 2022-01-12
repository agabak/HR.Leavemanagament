using HR.Leavemanagament.Domain;
using HR.Leavemanagament.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance
{
    public class LeaveManagamentDBContext: DbContext
    {
        public LeaveManagamentDBContext(DbContextOptions<LeaveManagamentDBContext> options)
            :base(options) {}

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagamentDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = "adminSysm";

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = "adminSysm";
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
    }
}
