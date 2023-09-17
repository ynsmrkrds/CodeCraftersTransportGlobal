using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportGlobal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransportRequests",
                columns: new[] { "ID", "CreatedDate", "DeliveryAddress", "IsDeleted", "LoadingAddress", "StatusType", "TransportDate", "TransportType", "UserID", "Volume", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(1917), "456 Elm Street, Los Angeles", false, "123 Main Street, New York", 0, new DateTime(2023, 9, 24, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(1905), 4, 2, 1000.0, 500.5 },
                    { 2, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(1947), "101 Pine Road, Miami", false, "789 Oak Avenue, Chicago", 2, new DateTime(2023, 9, 10, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(1946), 3, 2, 2000.0, 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "Email", "IsDeleted", "Name", "PasswordHash", "Surname", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(8996), "john.doe@gmail.com", false, "John", "wEXC+zsV9xjSjrlsyqK58SjE3IasyI327aF25jotP7/98elqf/+cd+KzKDv2PSPBaeSE0/8cPOnOJYtkZ3y1Eg==", "Doe", 0 },
                    { 2, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(9052), "mark.smith@gmail.com", false, "Mark", "wEXC+zsV9xjSjrlsyqK58SjE3IasyI327aF25jotP7/98elqf/+cd+KzKDv2PSPBaeSE0/8cPOnOJYtkZ3y1Eg==", "Smith", 1 }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "ReceiverUserID", "SenderUserID", "TransportRequestID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(5996), false, 2, 1, 2 },
                    { 2, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(6052), false, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Address", "CreatedDate", "Email", "IsDeleted", "Name", "OwnerUserID", "PhoneNumber" },
                values: new object[] { 1, "123 Main Street", new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(3353), "info@translogistics.com", false, "TransLogistics, LLC", 1, "(555) 123-4567" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "ID", "ChatID", "Content", "ContentType", "CreatedDate", "IsDeleted", "ReceiverUserID", "SenderUserID", "SendingDate" },
                values: new object[,]
                {
                    { 1, 1, "2", 0, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7609), false, 2, 1, new DateTime(2023, 9, 8, 14, 51, 23, 895, DateTimeKind.Local).AddTicks(7596) },
                    { 2, 1, "Our new offer to you is this:", 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7666), false, 2, 1, new DateTime(2023, 9, 8, 14, 51, 22, 895, DateTimeKind.Local).AddTicks(7665) },
                    { 3, 1, "Hello. The price is too high, 1500?", 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7671), false, 1, 2, new DateTime(2023, 9, 8, 14, 49, 22, 895, DateTimeKind.Local).AddTicks(7670) },
                    { 4, 1, "1", 0, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7676), false, 2, 1, new DateTime(2023, 9, 8, 14, 46, 23, 895, DateTimeKind.Local).AddTicks(7675) },
                    { 5, 1, "Hello. Here's what we're offering you:", 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7680), false, 2, 1, new DateTime(2023, 9, 8, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7679) },
                    { 6, 2, "3", 0, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7687), false, 2, 1, new DateTime(2023, 9, 17, 14, 46, 23, 895, DateTimeKind.Local).AddTicks(7686) },
                    { 7, 2, "Hello. Here's what we're offering you:", 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7691), false, 2, 1, new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(7690) }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "ID", "CompanyID", "CreatedDate", "IdentificationNumber", "IsDeleted", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(6258), "ABC 123", false, 0, 1 },
                    { 2, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(6284), "XYZ 789", false, 0, 0 },
                    { 3, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(6288), "NY12345", false, 0, 2 },
                    { 4, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(6291), "BREL-2023", false, 2, 3 },
                    { 5, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(6375), "N387BA", false, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "CompanyID", "CreatedDate", "Email", "IsDeleted", "Name", "Surname", "Title", "VehicleID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4697), "tommy.hudson@gmail.com", false, "Tommy", "Hudson", 0, 1 },
                    { 2, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4727), "jane.smith@gmail.com", false, "Jane", "Smith", 2, 1 },
                    { 3, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4732), "michael.johnson@gmail.com", false, "Michael", "Johnson", 1, 1 },
                    { 4, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4735), "emily.wilson@gmail.com", false, "Emily", "Wilson", 0, 2 },
                    { 5, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4738), "william.brown@gmail.com", false, "William", "Brown", 2, 2 },
                    { 6, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4746), "olivia.davis@gmail.com", false, "Olivia", "Davis", 0, 3 },
                    { 7, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4749), "james.lee@gmail.com", false, "James", "Lee", 2, 3 },
                    { 8, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4752), "sophia.clark@gmail.com", false, "Sophia", "Clark", 2, 3 },
                    { 9, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4755), "liam.hall@gmail.com", false, "Liam", "Hall", 1, 3 },
                    { 10, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(4759), "ava.white@gmail.com", false, "Ava", "White", 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "TransportContracts",
                columns: new[] { "ID", "CompanyID", "CreatedDate", "IsDeleted", "Price", "Status", "TransportRequestID", "UserID", "VehicleID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(544), false, 2000.0, 2, 2, 2, 2 },
                    { 2, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(577), false, 1500.0, 1, 2, 2, 2 },
                    { 3, 1, new DateTime(2023, 9, 17, 14, 46, 22, 896, DateTimeKind.Local).AddTicks(581), false, 2500.0, 0, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ID", "Comment", "CreatedDate", "IsDeleted", "Score", "TransportContractID" },
                values: new object[] { 1, "Great shipping service, arrived on time!", new DateTime(2023, 9, 17, 14, 46, 22, 895, DateTimeKind.Local).AddTicks(9110), false, 5, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportContracts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportContracts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportContracts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransportRequests",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportRequests",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
