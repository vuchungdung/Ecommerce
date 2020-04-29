using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class deleteSeoaliasInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 24, 14, 17, 51, 392, DateTimeKind.Local).AddTicks(5043),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 3, 22, 12, 3, 446, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("33544036-8229-499e-a8ac-550b99fad57e"),
                column: "ConcurrencyStamp",
                value: "827c63aa-51b9-411c-8dd2-c89a0e1d670c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0990f4f-c880-4705-a961-777e4a1a91d1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b987f53a-98a7-4645-acb3-62d62764e059", "AQAAAAEAACcQAAAAEMy6uj8qTkfpsOPnOPJBeIaiYD+kq6RE2ANKFzT5/O6CRCMh6GQOCM5XqwVVVZz6ug==" });

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
                values: new object[] { new DateTime(2020, 2, 24, 14, 17, 51, 428, DateTimeKind.Local).AddTicks(8524), 100000m, 200000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 3, 22, 12, 3, 446, DateTimeKind.Local).AddTicks(4620),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 24, 14, 17, 51, 392, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("33544036-8229-499e-a8ac-550b99fad57e"),
                column: "ConcurrencyStamp",
                value: "a0135922-d279-4d15-92f4-8fb90eae89b4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0990f4f-c880-4705-a961-777e4a1a91d1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca6515ef-05ae-4e6a-9981-f85c4c9eb2d9", "AQAAAAEAACcQAAAAELbzlgFsuE/ATeiPNI1GvnNnp7vJggqHH35ZbyOF3gsmqqfBxftN2BCfgr408dZzhg==" });

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
                values: new object[] { new DateTime(2020, 2, 3, 22, 12, 3, 477, DateTimeKind.Local).AddTicks(4988), 100000m, 200000m });
        }
    }
}
