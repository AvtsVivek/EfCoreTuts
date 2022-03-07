using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ef000302_PieBakeryConsole.Migrations;

public partial class One : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Categories",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Categories", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "Pies",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
          Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
          Portions_Minimum = table.Column<int>(type: "int", nullable: false),
          Portions_Maximum = table.Column<int>(type: "int", nullable: false),
          CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Pies", x => x.Id);
          table.ForeignKey(
                      name: "FK_Pies_Categories_CategoryId",
                      column: x => x.CategoryId,
                      principalTable: "Categories",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "Ingredient",
        columns: table => new
        {
          PieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          IsAllergen = table.Column<bool>(type: "bit", nullable: false),
          RelativeAmount = table.Column<double>(type: "float", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Ingredient", x => new { x.PieId, x.Id });
          table.ForeignKey(
                      name: "FK_Ingredient_Pies_PieId",
                      column: x => x.PieId,
                      principalTable: "Pies",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_Pies_CategoryId",
        table: "Pies",
        column: "CategoryId");
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Ingredient");

    migrationBuilder.DropTable(
        name: "Pies");

    migrationBuilder.DropTable(
        name: "Categories");
  }
}
