using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capenexislearners2023.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CoursesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilitatorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CoursesId);
                });

            migrationBuilder.CreateTable(
                name: "Facilitators",
                columns: table => new
                {
                    FacilitatorsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilitatorsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilitatorsSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilitatorsIdentityNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitators", x => x.FacilitatorsId);
                });

            migrationBuilder.CreateTable(
                name: "Learners",
                columns: table => new
                {
                    LearnersId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearnersSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearnersIdentityNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learners", x => x.LearnersId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Facilitators");

            migrationBuilder.DropTable(
                name: "Learners");
        }
    }
}
