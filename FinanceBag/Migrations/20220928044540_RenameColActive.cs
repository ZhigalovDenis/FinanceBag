using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceBag.Migrations
{
    public partial class RenameColActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrandingMode",
                table: "Actives",
                newName: "TradingMode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TradingMode",
                table: "Actives",
                newName: "TrandingMode");
        }
    }
}
