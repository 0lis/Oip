using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oip.Dal.Sqlite.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Oip");

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "Oip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ExtendedProperties = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uoms",
                schema: "Oip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Formula = table.Column<string>(type: "TEXT", nullable: true),
                    BaseUomId = table.Column<int>(type: "INTEGER", nullable: true),
                    ObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ExtendedProperties = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uoms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_Id",
                schema: "Oip",
                table: "Modules",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Module_Name",
                schema: "Oip",
                table: "Modules",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Uom_Id",
                schema: "Oip",
                table: "Uoms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uom_Name",
                schema: "Oip",
                table: "Uoms",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules",
                schema: "Oip");

            migrationBuilder.DropTable(
                name: "Uoms",
                schema: "Oip");
        }
    }
}
