using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomasos.Migrations
{
    public partial class dishtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeNavigationId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "DishTypeNavigationId",
                table: "Dishes",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DishTypeNavigationId",
                table: "Dishes",
                newName: "IX_Dishes_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishTypes_TypeId",
                table: "Dishes",
                column: "TypeId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishTypes_TypeId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Dishes",
                newName: "DishTypeNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_TypeId",
                table: "Dishes",
                newName: "IX_Dishes_DishTypeNavigationId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeNavigationId",
                table: "Dishes",
                column: "DishTypeNavigationId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
