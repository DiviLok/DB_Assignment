using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAssignment.Migrations
{
    /// <inheritdoc />
    public partial class changesInSeniorCitizenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "needs",
                table: "senior_citizen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "needs",
                table: "senior_citizen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
