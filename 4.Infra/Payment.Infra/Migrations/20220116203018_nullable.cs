using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Payment.Infra.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentInstituition_PaymentInstituitionId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentType_PaymentTypeId",
                table: "Expense");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentTypeId",
                table: "Expense",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentInstituitionId",
                table: "Expense",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentInstituition_PaymentInstituitionId",
                table: "Expense",
                column: "PaymentInstituitionId",
                principalTable: "PaymentInstituition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentType_PaymentTypeId",
                table: "Expense",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentInstituition_PaymentInstituitionId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentType_PaymentTypeId",
                table: "Expense");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentTypeId",
                table: "Expense",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentInstituitionId",
                table: "Expense",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
