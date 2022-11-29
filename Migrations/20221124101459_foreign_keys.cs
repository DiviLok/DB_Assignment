using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAssignment.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "care_giverID",
                table: "patient_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_patient_details_care_giverID",
                table: "patient_details",
                column: "care_giverID");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_details_care_givers_care_giverID",
                table: "patient_details",
                column: "care_giverID",
                principalTable: "care_givers",
                principalColumn: "care_giverID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_details_care_givers_care_giverID",
                table: "patient_details");

            migrationBuilder.DropIndex(
                name: "IX_patient_details_care_giverID",
                table: "patient_details");

            migrationBuilder.DropColumn(
                name: "care_giverID",
                table: "patient_details");
        }
    }
}
