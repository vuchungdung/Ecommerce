using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class changeDataImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("33544036-8229-499e-a8ac-550b99fad57e"),
                column: "ConcurrencyStamp",
                value: "0b4dc8b8-3f56-41f2-aa33-77b053320c5e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0990f4f-c880-4705-a961-777e4a1a91d1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a18885b-374e-4c7d-94ed-e8af60e0c6c8", "AQAAAAEAACcQAAAAEAv7z3ceJH42WPFEqQ/JwWh53GaLh/ud9t+5cr3XqCk6s0NLD+i5eMNcBxE0i2dZ3A==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 22, 49, 0, 89, DateTimeKind.Local).AddTicks(4539), 100000m, 200000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("33544036-8229-499e-a8ac-550b99fad57e"),
                column: "ConcurrencyStamp",
                value: "08615137-b759-4ceb-914e-d3682c42fd15");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0990f4f-c880-4705-a961-777e4a1a91d1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89075c19-97f2-46a7-8627-4cdc77d80361", "AQAAAAEAACcQAAAAEKI0fC6XejRFdzDPMetvSs2gyKyxTN9DECS9jB8d5AxDFmz5stjR3H16OjBHGRJh/A==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice", "Price" },
                values: new object[] { new DateTime(2020, 3, 10, 9, 49, 33, 143, DateTimeKind.Local).AddTicks(3050), 100000m, 200000m });
        }
    }
}
