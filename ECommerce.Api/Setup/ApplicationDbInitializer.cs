using ECommerce.Api.DataAccess;
using ECommerce.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Setup
{
    public static class ApplicationDbInitializer
    {
        public static void SeedData(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                });

            var user = new ApplicationUser {
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = "Admin@mail.com",
                NormalizedEmail = "Admin@mail.com".ToUpper()
            };

            var hashedPassword = new PasswordHasher<ApplicationUser>()
                .HashPassword(user, "Admin@123");
            user.PasswordHash = hashedPassword;

            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Category>()
                .HasData(new Category {
                    Id = 1,
                    ArName = "تصنيف 1",
                    EnName = "Category 1"
                });

            modelBuilder.Entity<Product>()
                .HasData(new Product {
                    Id = 1,
                    ArName = "المنتج 1",
                    EnName = "Product 1"
                });

            modelBuilder.Entity<ProductCategory>()
                .HasData(new ProductCategory {
                    Id = 1,
                    ProductId = 1,
                    CategoryId = 1
                });
        }
    }
}
