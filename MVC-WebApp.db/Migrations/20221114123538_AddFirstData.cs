using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_WebApp.db.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("582ed83d-ccc0-4681-9e0c-4f85fd64f996"), 15000m, "Кроссовки фирмы Nike", "/css/PHTTest.png", "Name1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("dd1f943b-141e-44c7-a02d-872a6c3c7e53"), 11000m, "Кроссовки фирмы Nike", "/css/PHTTest.png", "Name2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("56dd4601-3d58-44a4-b9e2-d3e9131c436b"), 17000m, "Кроссовки фирмы Nike", "/css/PHTTest.png", "Name3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56dd4601-3d58-44a4-b9e2-d3e9131c436b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("582ed83d-ccc0-4681-9e0c-4f85fd64f996"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd1f943b-141e-44c7-a02d-872a6c3c7e53"));
        }
    }
}
