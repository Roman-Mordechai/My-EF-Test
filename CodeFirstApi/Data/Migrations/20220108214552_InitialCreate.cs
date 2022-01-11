using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcFrames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DcManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFrames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcFrames_DcManagers_DcManagerId",
                        column: x => x.DcManagerId,
                        principalTable: "DcManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcClases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DcFrameId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcClases_DcFrames_DcFrameId",
                        column: x => x.DcFrameId,
                        principalTable: "DcFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcClases_DcFrameId",
                table: "DcClases",
                column: "DcFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_DcFrames_DcManagerId",
                table: "DcFrames",
                column: "DcManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcClases");

            migrationBuilder.DropTable(
                name: "DcFrames");

            migrationBuilder.DropTable(
                name: "DcManagers");
        }
    }
}
