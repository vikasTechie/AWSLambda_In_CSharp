using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagerDatabase.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pallets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sizeId = table.Column<int>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Isplacede = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pallets_Size_sizeId",
                        column: x => x.sizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pallets_sizeId",
                table: "pallets",
                column: "sizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pallets");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
