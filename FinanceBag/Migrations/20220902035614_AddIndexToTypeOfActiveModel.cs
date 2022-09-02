using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceBag.Migrations
{
    public partial class AddIndexToTypeOfActiveModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Type_Index",
                table: "TypeOfActives",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Type_Index",
                table: "TypeOfActives");
        }
    }
}
