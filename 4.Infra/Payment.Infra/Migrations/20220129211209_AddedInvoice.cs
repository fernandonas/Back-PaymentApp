using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Infra.Migrations
{
    public partial class AddedInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Invoice",
                table: "Expense",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice",
                table: "Expense");
        }
    }
}
