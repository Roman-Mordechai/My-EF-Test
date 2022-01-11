using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstApi.Migrations
{
    public partial class UpdateManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DcFrames",
                newName: "FrameName");

            migrationBuilder.AddColumn<int>(
                name: "FrameCode",
                table: "DcFrames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrameCode",
                table: "DcFrames");

            migrationBuilder.RenameColumn(
                name: "FrameName",
                table: "DcFrames",
                newName: "Name");
        }
    }
}
