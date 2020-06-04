using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class _7OA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicament_MedicamentIdMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicament_PrescriptionIdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_IdPrescription",
                table: "PrescriptionMedicament",
                column: "IdPrescription",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                table: "PrescriptionMedicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                table: "PrescriptionMedicament",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicament_IdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicament",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_MedicamentIdMedicament",
                table: "PrescriptionMedicament",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_PrescriptionIdPrescription",
                table: "PrescriptionMedicament",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicament",
                column: "MedicamentIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicament",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
