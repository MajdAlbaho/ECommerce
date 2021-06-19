using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.DataAccess.Entities
{
    public partial class ECommerceContext : IdentityDbContext<ApplicationUser>
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
