using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AttachmentsService.BI.Migrations
{
    public partial class FixAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                table: "Attachments",
                name: "DeathDate",
                nullable: true);

            migrationBuilder.DropColumn(
                table: "Attachments",
                name: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               table: "Attachments",
               name: "DeathDate");

            migrationBuilder.AddColumn<string>(
                table: "Attachments",
                name: "Name");
        }
    }
}
