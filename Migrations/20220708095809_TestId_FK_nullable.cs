using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class TestId_FK_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_TestMgmt_TestId",
                table: "RegisterPatient");

            migrationBuilder.DropIndex(
                name: "IX_RegisterPatient_TestId",
                table: "RegisterPatient");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "RegisterPatient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_TestId",
                table: "RegisterPatient",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_TestMgmt_TestId",
                table: "RegisterPatient",
                column: "TestId",
                principalTable: "TestMgmt",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_TestMgmt_TestId",
                table: "RegisterPatient");

            migrationBuilder.DropIndex(
                name: "IX_RegisterPatient_TestId",
                table: "RegisterPatient");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "RegisterPatient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_TestId",
                table: "RegisterPatient",
                column: "TestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_TestMgmt_TestId",
                table: "RegisterPatient",
                column: "TestId",
                principalTable: "TestMgmt",
                principalColumn: "TestId");
        }
    }
}
