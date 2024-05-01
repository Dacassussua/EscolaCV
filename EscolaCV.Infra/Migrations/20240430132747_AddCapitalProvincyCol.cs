using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaCV.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCapitalProvincyCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capital",
                table: "Provincia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capital",
                table: "Provincia");
        }
    }
}
