using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAssignment.Migrations
{
    /// <inheritdoc />
    public partial class m2mrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_details_care_givers_care_giverID",
                table: "patient_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patient_details",
                table: "patient_details");

            migrationBuilder.RenameTable(
                name: "patient_details",
                newName: "senior_citizen");

            migrationBuilder.RenameIndex(
                name: "IX_patient_details_care_giverID",
                table: "senior_citizen",
                newName: "IX_senior_citizen_care_giverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_senior_citizen",
                table: "senior_citizen",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "services_and_senior",
                columns: table => new
                {
                    seniorCitizenID = table.Column<int>(type: "int", nullable: false),
                    serviceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_and_senior", x => new { x.serviceID, x.seniorCitizenID });
                    table.ForeignKey(
                        name: "FK_services_and_senior_senior_citizen_seniorCitizenID",
                        column: x => x.seniorCitizenID,
                        principalTable: "senior_citizen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_services_and_senior_services_by_city_serviceID",
                        column: x => x.serviceID,
                        principalTable: "services_by_city",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_and_senior_seniorCitizenID",
                table: "services_and_senior",
                column: "seniorCitizenID");

            migrationBuilder.AddForeignKey(
                name: "FK_senior_citizen_care_givers_care_giverID",
                table: "senior_citizen",
                column: "care_giverID",
                principalTable: "care_givers",
                principalColumn: "care_giverID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_senior_citizen_care_givers_care_giverID",
                table: "senior_citizen");

            migrationBuilder.DropTable(
                name: "services_and_senior");

            migrationBuilder.DropPrimaryKey(
                name: "PK_senior_citizen",
                table: "senior_citizen");

            migrationBuilder.RenameTable(
                name: "senior_citizen",
                newName: "patient_details");

            migrationBuilder.RenameIndex(
                name: "IX_senior_citizen_care_giverID",
                table: "patient_details",
                newName: "IX_patient_details_care_giverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patient_details",
                table: "patient_details",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_details_care_givers_care_giverID",
                table: "patient_details",
                column: "care_giverID",
                principalTable: "care_givers",
                principalColumn: "care_giverID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
