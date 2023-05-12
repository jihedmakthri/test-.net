using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructue.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentreVaccination",
                columns: table => new
                {
                    CentreVaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NbChaises = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<int>(type: "int", nullable: false),
                    ResponsableCentre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreVaccination", x => x.CentreVaccinationId);
                });

            migrationBuilder.CreateTable(
                name: "Citoyen",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Addresse_CodePostal = table.Column<int>(type: "int", nullable: false),
                    Addresse_Rue = table.Column<int>(type: "int", nullable: false),
                    Addresse_Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CitoyenId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEvax = table.Column<int>(type: "int", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citoyen", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Vaccin",
                columns: table => new
                {
                    VaccinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateValidite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    TypeVaccin = table.Column<int>(type: "int", nullable: false),
                    CentreDeVacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccin", x => x.VaccinId);
                    table.ForeignKey(
                        name: "FK_Vaccin_CentreVaccination_CentreDeVacId",
                        column: x => x.CentreDeVacId,
                        principalTable: "CentreVaccination",
                        principalColumn: "CentreVaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    DateVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitoyenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VaccinId = table.Column<int>(type: "int", nullable: false),
                    CodeInfirmiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => new { x.DateVaccination, x.VaccinId, x.CitoyenId });
                    table.ForeignKey(
                        name: "FK_RendezVous_Citoyen_CitoyenId",
                        column: x => x.CitoyenId,
                        principalTable: "Citoyen",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Vaccin_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "Vaccin",
                        principalColumn: "VaccinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_CitoyenId",
                table: "RendezVous",
                column: "CitoyenId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_VaccinId",
                table: "RendezVous",
                column: "VaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccin_CentreDeVacId",
                table: "Vaccin",
                column: "CentreDeVacId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "Citoyen");

            migrationBuilder.DropTable(
                name: "Vaccin");

            migrationBuilder.DropTable(
                name: "CentreVaccination");
        }
    }
}
