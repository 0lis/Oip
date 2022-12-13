using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oip.Dal.Sqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "olp");

            migrationBuilder.CreateTable(
                name: "Uoms",
                schema: "olp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Formula = table.Column<string>(type: "TEXT", nullable: true),
                    BaseUomId = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ExtendetProperty = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uoms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uom_Id",
                schema: "olp",
                table: "Uoms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uom_Name",
                schema: "olp",
                table: "Uoms",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uoms",
                schema: "olp");
        }
    }
}
