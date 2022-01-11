using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstApi.Migrations
{
    public partial class UpdateManager1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DcManagers",
                newName: "ManagerName");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "DcManagers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "DcManagers");

            migrationBuilder.RenameColumn(
                name: "ManagerName",
                table: "DcManagers",
                newName: "Name");
        }
    }
}
