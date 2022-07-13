using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class RP_made_all_FK_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_Packages_PackageID",
                table: "RegisterPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_Patient_PatientID",
                table: "RegisterPatient");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "RegisterPatient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PackageID",
                table: "RegisterPatient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RegisterPatient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_Packages_PackageID",
                table: "RegisterPatient",
                column: "PackageID",
                principalTable: "Packages",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_Patient_PatientID",
                table: "RegisterPatient",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_Packages_PackageID",
                table: "RegisterPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterPatient_Patient_PatientID",
                table: "RegisterPatient");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "RegisterPatient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PackageID",
                table: "RegisterPatient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RegisterPatient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_AspNetUsers_Id",
                table: "RegisterPatient",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_Packages_PackageID",
                table: "RegisterPatient",
                column: "PackageID",
                principalTable: "Packages",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterPatient_Patient_PatientID",
                table: "RegisterPatient",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
