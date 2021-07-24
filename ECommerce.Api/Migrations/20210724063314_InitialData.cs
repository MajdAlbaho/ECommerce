using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Api.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9707ed21-9b30-43e5-b0f5-c31abb101462", "5c36936f-3660-461e-ab3b-c021ed68dfef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4220bbc-361f-471d-bf59-754ce7095026", 0, "becf8f23-6104-4e6e-9dae-84a464e6d774", "Admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEE4Re04dL9F8DoUV3kzYl0II6XU3KJ1vvBrLd6w+xzGUylHwBmvGyL8Rri53am9Xaw==", null, false, "cefac653-e17c-4c25-a40d-1a3c90784232", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ArName", "EnName", "LastModifiedDate" },
                values: new object[] { 1, "تصنيف 1", "Category 1", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArDescription", "ArName", "EnDescription", "EnName", "ImageSource", "LastModifiedDate" },
                values: new object[] { 1, null, "المنتج 1", null, "Product 1", null, null });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "LastModifiedDate", "ProductId" },
                values: new object[] { 1, 1, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9707ed21-9b30-43e5-b0f5-c31abb101462");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4220bbc-361f-471d-bf59-754ce7095026");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
