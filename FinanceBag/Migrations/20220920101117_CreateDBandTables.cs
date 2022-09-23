using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceBag.Migrations
{
    public partial class CreateDBandTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeOfActives",
                columns: table => new
                {
                    TypeOfActive_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfActives", x => x.TypeOfActive_id);
                });

            migrationBuilder.CreateTable(
                name: "Actives",
                columns: table => new
                {
                    ISIN_id = table.Column<string>(type: "text", nullable: false),
                    Ticker = table.Column<string>(type: "text", nullable: false),
                    TypeOfActive_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actives", x => x.ISIN_id);
                    table.ForeignKey(
                        name: "FK_Actives_TypeOfActives_TypeOfActive_id",
                        column: x => x.TypeOfActive_id,
                        principalTable: "TypeOfActives",
                        principalColumn: "TypeOfActive_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Deal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Sum = table.Column<decimal>(type: "numeric", nullable: false),
                    ISIN_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Deal_id);
                    table.ForeignKey(
                        name: "FK_Deals_Actives_ISIN_id",
                        column: x => x.ISIN_id,
                        principalTable: "Actives",
                        principalColumn: "ISIN_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actives_TypeOfActive_id",
                table: "Actives",
                column: "TypeOfActive_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ISIN_id",
                table: "Deals",
                column: "ISIN_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Actives");

            migrationBuilder.DropTable(
                name: "TypeOfActives");
        }
    }
}
