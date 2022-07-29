using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class spGetStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetStats
                            @date1 DateTime, @date2 DateTime, @selection int
                            as
                            Begin
                            IF (@selection = 1)                          
                                SELECT* FROM RegisterPatient WHERE RegDateTime
                               BETWEEN @date1
                               AND @date2

                            ELSE IF (@selection = 2)
                                SELECT* FROM Payment WHERE PaymentDate
                               BETWEEN @date1
                               AND @date2

                            ELSE IF (@selection = 3)
                                SELECT* FROM Patient WHERE DateOfBirth
                               BETWEEN @date1
                               AND @date2
                            End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStats";
            migrationBuilder.Sql(procedure);
        }
    }
}
