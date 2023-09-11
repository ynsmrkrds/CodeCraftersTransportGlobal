using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAndCompanyRelationsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerUserID",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerUserID",
                table: "Companies",
                column: "OwnerUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerUserID",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerUserID",
                table: "Companies",
                column: "OwnerUserID",
                unique: true);
        }
    }
}
