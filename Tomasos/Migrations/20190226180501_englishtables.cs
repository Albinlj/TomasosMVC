using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomasos.Migrations
{
    public partial class englishtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestallning_AspNetUsers_UserId",
                table: "Bestallning");

            migrationBuilder.DropForeignKey(
                name: "FK_BestallningMatratt_Matratt_DishId",
                table: "BestallningMatratt");

            migrationBuilder.DropForeignKey(
                name: "FK_BestallningMatratt_Bestallning_OrderId",
                table: "BestallningMatratt");

            migrationBuilder.DropForeignKey(
                name: "FK_Matratt_MatrattTyp_DishTypeNavigationId",
                table: "Matratt");

            migrationBuilder.DropForeignKey(
                name: "FK_MatrattProdukt_Matratt_DishId",
                table: "MatrattProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_MatrattProdukt_Produkt_IngredientId",
                table: "MatrattProdukt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produkt",
                table: "Produkt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatrattTyp",
                table: "MatrattTyp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatrattProdukt",
                table: "MatrattProdukt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matratt",
                table: "Matratt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BestallningMatratt",
                table: "BestallningMatratt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bestallning",
                table: "Bestallning");

            migrationBuilder.RenameTable(
                name: "Produkt",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "MatrattTyp",
                newName: "DishTypes");

            migrationBuilder.RenameTable(
                name: "MatrattProdukt",
                newName: "DishIngredients");

            migrationBuilder.RenameTable(
                name: "Matratt",
                newName: "Dishes");

            migrationBuilder.RenameTable(
                name: "BestallningMatratt",
                newName: "OrderDishes");

            migrationBuilder.RenameTable(
                name: "Bestallning",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_MatrattProdukt_IngredientId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_MatrattProdukt_DishId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Matratt_DishTypeNavigationId",
                table: "Dishes",
                newName: "IX_Dishes_DishTypeNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_BestallningMatratt_OrderId",
                table: "OrderDishes",
                newName: "IX_OrderDishes_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BestallningMatratt_DishId",
                table: "OrderDishes",
                newName: "IX_OrderDishes_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Bestallning_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishTypes",
                table: "DishTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeNavigationId",
                table: "Dishes",
                column: "DishTypeNavigationId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Dishes_DishId",
                table: "OrderDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeNavigationId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Dishes_DishId",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishTypes",
                table: "DishTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Bestallning");

            migrationBuilder.RenameTable(
                name: "OrderDishes",
                newName: "BestallningMatratt");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Produkt");

            migrationBuilder.RenameTable(
                name: "DishTypes",
                newName: "MatrattTyp");

            migrationBuilder.RenameTable(
                name: "DishIngredients",
                newName: "MatrattProdukt");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Matratt");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Bestallning",
                newName: "IX_Bestallning_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDishes_OrderId",
                table: "BestallningMatratt",
                newName: "IX_BestallningMatratt_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDishes_DishId",
                table: "BestallningMatratt",
                newName: "IX_BestallningMatratt_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "MatrattProdukt",
                newName: "IX_MatrattProdukt_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_DishId",
                table: "MatrattProdukt",
                newName: "IX_MatrattProdukt_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DishTypeNavigationId",
                table: "Matratt",
                newName: "IX_Matratt_DishTypeNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bestallning",
                table: "Bestallning",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BestallningMatratt",
                table: "BestallningMatratt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produkt",
                table: "Produkt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatrattTyp",
                table: "MatrattTyp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatrattProdukt",
                table: "MatrattProdukt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matratt",
                table: "Matratt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestallning_AspNetUsers_UserId",
                table: "Bestallning",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BestallningMatratt_Matratt_DishId",
                table: "BestallningMatratt",
                column: "DishId",
                principalTable: "Matratt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BestallningMatratt_Bestallning_OrderId",
                table: "BestallningMatratt",
                column: "OrderId",
                principalTable: "Bestallning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matratt_MatrattTyp_DishTypeNavigationId",
                table: "Matratt",
                column: "DishTypeNavigationId",
                principalTable: "MatrattTyp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatrattProdukt_Matratt_DishId",
                table: "MatrattProdukt",
                column: "DishId",
                principalTable: "Matratt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatrattProdukt_Produkt_IngredientId",
                table: "MatrattProdukt",
                column: "IngredientId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
