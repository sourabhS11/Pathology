using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class RP_update_FK_UserId_to_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_UserId",
                table: "RegisterPatient");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RegisterPatient",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_RegisterPatient_UserId",
                table: "RegisterPatient",
                newName: "IX_RegisterPatient_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RegisterPatient",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisterPatient_Id",
                table: "RegisterPatient",
                newName: "IX_RegisterPatient_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_UserId",
                table: "RegisterPatient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
