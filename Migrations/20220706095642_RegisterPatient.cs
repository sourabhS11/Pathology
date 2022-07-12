using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class RegisterPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TestName",
                table: "TestMgmt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RegisterPatient",
                columns: table => new
                {
                    RegisterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    PackageID = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsReportGenerated = table.Column<bool>(type: "bit", nullable: false),
                    RoportPDF = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterPatient", x => x.RegisterID);
                    table.ForeignKey(
                        name: "FK_RegisterPatient_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterPatient_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterPatient_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterPatient_TestMgmt_TestId",
                        column: x => x.TestId,
                        principalTable: "TestMgmt",
                        principalColumn: "TestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_PackageID",
                table: "RegisterPatient",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_PatientID",
                table: "RegisterPatient",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_TestId",
                table: "RegisterPatient",
                column: "TestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterPatient_UserId",
                table: "RegisterPatient",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterPatient");

            migrationBuilder.AlterColumn<string>(
                name: "TestName",
                table: "TestMgmt",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
