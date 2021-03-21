using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class Status_col_added_Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "UserTracking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTracking_StatusId",
                table: "UserTracking",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTracking_Status_StatusId",
                table: "UserTracking",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTracking_Status_StatusId",
                table: "UserTracking");

            migrationBuilder.DropIndex(
                name: "IX_UserTracking_StatusId",
                table: "UserTracking");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "UserTracking");
        }
    }
}
