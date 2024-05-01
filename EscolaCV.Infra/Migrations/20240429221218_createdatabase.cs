using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaCV.Infra.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    PaisId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincia_pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    EscolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumSalas = table.Column<int>(type: "int", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.EscolaId);
                    table.ForeignKey(
                        name: "FK_Escola_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escola_ProvinciaId",
                table: "Escola",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincia",
                column: "PaisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escola");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
