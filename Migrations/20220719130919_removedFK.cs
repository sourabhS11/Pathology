using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class removedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Patient_RegisterID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_RegisterID",
                table: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Payment_RegisterID",
                table: "Payment",
                column: "RegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Patient_RegisterID",
                table: "Payment",
                column: "RegisterID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
