using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ef000301_RecordsConsole.Migrations;

public partial class InitialMigration : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Pies",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
          Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
          ServingSize_minium = table.Column<int>(type: "int", nullable: false),
          ServingSize_maxium = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Pies", x => x.Id);
        });
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Pies");
  }
}
