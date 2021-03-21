using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class AllSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LookUpMasterConst = table.Column<string>(nullable: true),
                    LookUpMasterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LookUpDetailConst = table.Column<string>(nullable: true),
                    LookUpDetailName = table.Column<string>(nullable: true),
                    LookUpDetailOrder = table.Column<int>(nullable: false),
                    LookUpMasterId = table.Column<int>(nullable: true),
                    ParentLookUpDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpDetail_LookUpMaster_LookUpMasterId",
                        column: x => x.LookUpMasterId,
                        principalTable: "LookUpMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpDetail_LookUpDetail_ParentLookUpDetailId",
                        column: x => x.ParentLookUpDetailId,
                        principalTable: "LookUpDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDetail_LookUpMasterId",
                table: "LookUpDetail",
                column: "LookUpMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDetail_ParentLookUpDetailId",
                table: "LookUpDetail",
                column: "ParentLookUpDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpDetail");

            migrationBuilder.DropTable(
                name: "LookUpMaster");
        }
    }
}
