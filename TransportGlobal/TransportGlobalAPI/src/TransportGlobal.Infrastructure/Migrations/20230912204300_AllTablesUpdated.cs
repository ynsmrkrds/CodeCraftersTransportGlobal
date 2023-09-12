using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllTablesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_TransportRequests_TransportRequestID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_OwnerUserID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportContracts_TransportRequests_TransportRequestID",
                table: "TransportContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportContracts_Users_UserID",
                table: "TransportContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyID",
                table: "Vehicles");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransportRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransportContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Chats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_TransportRequests_TransportRequestID",
                table: "Chats",
                column: "TransportRequestID",
                principalTable: "TransportRequests",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_OwnerUserID",
                table: "Companies",
                column: "OwnerUserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyID",
                table: "Employees",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages",
                column: "ChatID",
                principalTable: "Chats",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportContracts_TransportRequests_TransportRequestID",
                table: "TransportContracts",
                column: "TransportRequestID",
                principalTable: "TransportRequests",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportContracts_Users_UserID",
                table: "TransportContracts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyID",
                table: "Vehicles",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_TransportRequests_TransportRequestID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_OwnerUserID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportContracts_TransportRequests_TransportRequestID",
                table: "TransportContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportContracts_Users_UserID",
                table: "TransportContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransportRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransportContracts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Chats");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_TransportRequests_TransportRequestID",
                table: "Chats",
                column: "TransportRequestID",
                principalTable: "TransportRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_OwnerUserID",
                table: "Companies",
                column: "OwnerUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyID",
                table: "Employees",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages",
                column: "ChatID",
                principalTable: "Chats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportContracts_TransportRequests_TransportRequestID",
                table: "TransportContracts",
                column: "TransportRequestID",
                principalTable: "TransportRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportContracts_Users_UserID",
                table: "TransportContracts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyID",
                table: "Vehicles",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
