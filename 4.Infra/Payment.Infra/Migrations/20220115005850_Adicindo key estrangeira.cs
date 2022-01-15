using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Infra.Migrations
{
    public partial class Adicindokeyestrangeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Expense_PaymentInstituitionId",
                table: "Expense",
                column: "PaymentInstituitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PaymentTypeId",
                table: "Expense",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentInstituition_PaymentInstituitionId",
                table: "Expense",
                column: "PaymentInstituitionId",
                principalTable: "PaymentInstituition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentType_PaymentTypeId",
                table: "Expense",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentInstituition_PaymentInstituitionId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentType_PaymentTypeId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_PaymentInstituitionId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_PaymentTypeId",
                table: "Expense");
        }
    }
}
