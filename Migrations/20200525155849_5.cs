using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    PrescriptionIdPrescription = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                    table.ForeignKey(
                        name: "FK_Medicaments_Prescriptions_PrescriptionIdPrescription",
                        column: x => x.PrescriptionIdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    PrescriptionIdPrescription = table.Column<int>(nullable: true),
                    MedicamentIdMedicament = table.Column<int>(nullable: true),
                    Dose = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Medicaments_MedicamentIdMedicament",
                        column: x => x.MedicamentIdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Prescriptions_PrescriptionIdPrescription",
                        column: x => x.PrescriptionIdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_PrescriptionIdPrescription",
                table: "Medicaments",
                column: "PrescriptionIdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_MedicamentIdMedicament",
                table: "PrescriptionMedicament",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_PrescriptionIdPrescription",
                table: "PrescriptionMedicament",
                column: "PrescriptionIdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicament");

            migrationBuilder.DropTable(
                name: "Medicaments");
        }
    }
}
