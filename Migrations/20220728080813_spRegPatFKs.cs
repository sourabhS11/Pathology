using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class spRegPatFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spRegPatFKs
                            @date1 DateTime, @date2 DateTime
                            as
                            Begin
                                SELECT 
                                Patient.PatientName, Patient.PatientID, 
                                TestMgmt.TestName, TestMgmt.TestId, 
                                Packages.PackageName, Packages.PackageID,
								RegisterPatient.RegisterID, RegisterPatient.Id, RegisterPatient.RegDateTime, RegisterPatient.TotalAmount, 
								RegisterPatient.IsPaymentDone, RegisterPatient.IsReportGenerated, RegisterPatient.RoportPDF
                                FROM RegisterPatient
                                FULL OUTER JOIN Patient ON RegisterPatient.PatientID = Patient.PatientID

                                FULL OUTER JOIN TestMgmt ON RegisterPatient.TestId = TestMgmt.TestId

                                FULL OUTER JOIN Packages ON RegisterPatient.PackageID = Packages.PackageID

                                WHERE RegDateTime
                                BETWEEN @date1
                                AND @date2
                            End";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spRegPatFKs";
            migrationBuilder.Sql(procedure);
        }
    }
}
