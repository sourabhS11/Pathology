using Microsoft.EntityFrameworkCore.Migrations;

namespace Pathology.Migrations
{
    public partial class spGetminmax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetminmax
                            @date1 DateTime, @date2 DateTime, @selection int
                            as
                            Begin
                            IF (@selection = 4)  						
							    SELECT TestId,
								COUNT(TestId) as NumberOfOccurance
								FROM RegisterPatient
								WHERE RegDateTime BETWEEN @date1 AND @date2
								GROUP BY TestId
								ORDER BY COUNT(TestId) DESC;
                            ELSE IF (@selection = 5)
							    SELECT TestId,
								COUNT(TestId) as NumberOfOccurance
								FROM RegisterPatient
								WHERE RegDateTime BETWEEN @date1 AND @date2
								GROUP BY TestId
								ORDER BY COUNT(TestId) ASC;
							ELSE IF (@selection = 6)
							    SELECT PackageID,
								COUNT(PackageID) as NumberOfOccurance
								FROM RegisterPatient
								WHERE RegDateTime BETWEEN @date1 AND @date2
								GROUP BY PackageID
								ORDER BY COUNT(PackageID) DESC;
							ELSE IF (@selection = 7)
							    SELECT PackageID,
								COUNT(PackageID) as NumberOfOccurance
								FROM RegisterPatient
								WHERE RegDateTime BETWEEN @date1 AND @date2
								GROUP BY PackageID
								ORDER BY COUNT(PackageID) ASC;
                            End";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetminmax";
            migrationBuilder.Sql(procedure);
        }
    }
}
