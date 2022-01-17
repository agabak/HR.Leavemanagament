using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "93d75abf-c0a1-45c6-8947-185d0da53e05",
                    UserId = "4449b9fe-1862-43b4-9cdf-f93e78da198a"
                },
                 new IdentityUserRole<string>
                 {
                     RoleId = "b0c8bcf7-0cdb-4038-a1b5-f054a41105d5",
                     UserId = "55ed57d6-aee6-4a89-b4fc-16037edf92d1"
                 }
                );
        }
    }
}
