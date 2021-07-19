using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class _20210718162611_DocumnetDocShowOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocShowOrder",
                table: "BusinessDocument",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocShowOrder",
                table: "BusinessDocument");
        }
    }
}
