using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomasos.Migrations.Tomasos
{
    public partial class noKunds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestallning_Kund",
                table: "Bestallning");

            migrationBuilder.DropTable(
                name: "Kund");

            migrationBuilder.DropIndex(
                name: "IX_Bestallning_KundID",
                table: "Bestallning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kund",
                columns: table => new
                {
                    KundID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gatuadress = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Namn = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Postnr = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Postort = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kund", x => x.KundID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestallning_KundID",
                table: "Bestallning",
                column: "KundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestallning_Kund",
                table: "Bestallning",
                column: "KundID",
                principalTable: "Kund",
                principalColumn: "KundID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
