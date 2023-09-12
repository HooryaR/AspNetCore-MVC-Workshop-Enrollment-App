using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollements",
                columns: table => new
                {
                    EnrollementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollements", x => x.EnrollementId);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.WorkshopId);
                });

            migrationBuilder.CreateTable(
                name: "EnrollementWorkshop",
                columns: table => new
                {
                    EnrollementsEnrollementId = table.Column<int>(type: "int", nullable: false),
                    WorkshopsWorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollementWorkshop", x => new { x.EnrollementsEnrollementId, x.WorkshopsWorkshopId });
                    table.ForeignKey(
                        name: "FK_EnrollementWorkshop_Enrollements_EnrollementsEnrollementId",
                        column: x => x.EnrollementsEnrollementId,
                        principalTable: "Enrollements",
                        principalColumn: "EnrollementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollementWorkshop_Workshops_WorkshopsWorkshopId",
                        column: x => x.WorkshopsWorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrollementWorkshop_WorkshopsWorkshopId",
                table: "EnrollementWorkshop",
                column: "WorkshopsWorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollementWorkshop");

            migrationBuilder.DropTable(
                name: "Enrollements");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
