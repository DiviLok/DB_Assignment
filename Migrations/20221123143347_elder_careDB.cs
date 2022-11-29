using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAssignment.Migrations
{
    /// <inheritdoc />
    public partial class eldercareDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authentications",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authentications", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "care_givers",
                columns: table => new
                {
                    caregiverID = table.Column<int>(name: "care_giverID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<int>(name: "phone_number", type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    emailid = table.Column<string>(name: "email_id", type: "nvarchar(max)", nullable: false),
                    shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drivinglicense = table.Column<bool>(name: "driving_license", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_care_givers", x => x.caregiverID);
                });

            migrationBuilder.CreateTable(
                name: "patient_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<int>(name: "phone_number", type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    needs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_details", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "services_by_city",
                columns: table => new
                {
                    serviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servicename = table.Column<string>(name: "service_name", type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_by_city", x => x.serviceID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authentications");

            migrationBuilder.DropTable(
                name: "care_givers");

            migrationBuilder.DropTable(
                name: "patient_details");

            migrationBuilder.DropTable(
                name: "services_by_city");
        }
    }
}
