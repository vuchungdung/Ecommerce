using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class addProductImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 24, 14, 17, 51, 392, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 24, 14, 17, 51, 392, DateTimeKind.Local).AddTicks(5043),
                oldClrType: typeof(DateTime));

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
    }
}
