using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AliFitnessAE.Migrations
{
    public partial class FullAuditedEntity_AllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "UserType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "UserTracking",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserTracking",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTracking",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "LookUpMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "LookUpMaster",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LookUpMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "LookUpDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "LookUpDetail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LookUpDetail",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "DocumentType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "DocumentType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DocumentType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "BusinessDocumentAttachment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "BusinessDocumentAttachment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BusinessDocumentAttachment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "BusinessDocument",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "BusinessDocument",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BusinessDocument",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "UserTracking");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserTracking");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTracking");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "LookUpMaster");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "LookUpMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LookUpMaster");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "LookUpDetail");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "LookUpDetail");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LookUpDetail");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "DocumentType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "DocumentType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DocumentType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "BusinessDocumentAttachment");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "BusinessDocumentAttachment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BusinessDocumentAttachment");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "BusinessDocument");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "BusinessDocument");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BusinessDocument");
        }
    }
}
