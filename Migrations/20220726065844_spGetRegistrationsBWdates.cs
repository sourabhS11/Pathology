using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class spGetRegistrationsBWdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetRegistrationsBWdates
                            @date1 DateTime, @date2 DateTime
                            as
                            Begin
                                SELECT * FROM RegisterPatient WHERE RegDateTime
                                BETWEEN @date1
                                AND @date2
                            End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetRegistrationsBWdates";
            migrationBuilder.Sql(procedure);
        }
    }
}
