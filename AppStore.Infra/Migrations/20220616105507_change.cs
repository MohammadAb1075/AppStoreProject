using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Infra.Data.Sql.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 1);
        }
    }
}
