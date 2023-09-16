using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransportContractTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgreed",
                table: "TransportContracts");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TransportContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TransportContracts");

            migrationBuilder.AddColumn<bool>(
                name: "IsAgreed",
                table: "TransportContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
