using Microsoft.EntityFrameworkCore.Migrations;

namespace LCWTest.Migrations
{
    public partial class MigrationV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CustomerOrders",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomerOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomerOrders");
        }
    }
}
