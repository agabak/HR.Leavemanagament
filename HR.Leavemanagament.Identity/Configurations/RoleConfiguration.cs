using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Leavemanagament.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "b0c8bcf7-0cdb-4038-a1b5-f054a41105d5",
                     Name = "Employee",
                     NormalizedName = "EMPLOYEE"
                 },
                 new IdentityRole
                 {
                     Id = "93d75abf-c0a1-45c6-8947-185d0da53e05",
                     Name = "Administractor",
                     NormalizedName = "ADMINISTRACTOR"
                 } );
        }
    }
}
