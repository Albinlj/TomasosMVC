using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomasos.Migrations
{
    public partial class decimalprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
