using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class publicstringProfilePhotoPathgetset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "AbpUsers");
        }
    }
}
