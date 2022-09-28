using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceBag.Migrations
{
    public partial class AddColumnToActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrandingMode",
                table: "Actives",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrandingMode",
                table: "Actives");
        }
    }
}
