using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransportContractTablesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAgreed",
                table: "TransportContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgreed",
                table: "TransportContracts");
        }
    }
}
