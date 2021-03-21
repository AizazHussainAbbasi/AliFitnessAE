using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class usertypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_UserType_UserTypeId",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "AbpUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_UserType_UserTypeId",
                table: "AbpUsers",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_UserType_UserTypeId",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "AbpUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_UserType_UserTypeId",
                table: "AbpUsers",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
