using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReviewTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportContractID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_TransportContracts_TransportContractID",
                        column: x => x.TransportContractID,
                        principalTable: "TransportContracts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TransportContractID",
                table: "Reviews",
                column: "TransportContractID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
