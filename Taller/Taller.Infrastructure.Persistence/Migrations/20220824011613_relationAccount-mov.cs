using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Taller.Infrastructure.Persistence.Migrations
{
    public partial class relationAccountmov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Movement",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Movement_AccountId",
                table: "Movement",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Account_AccountId",
                table: "Movement",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Account_AccountId",
                table: "Movement");

            migrationBuilder.DropIndex(
                name: "IX_Movement_AccountId",
                table: "Movement");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Movement");
        }
    }
}
