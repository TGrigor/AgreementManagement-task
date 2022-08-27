using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgreementManagement.Data.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupCode",
                table: "ProductGroup",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductNumber",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProductGroup",
                columns: new[] { "Id", "CreatedOn", "GroupCode", "GroupDescription", "IsDeleted", "UpdatedOn" },
                values: new object[] { 1, new DateTime(2022, 8, 27, 15, 39, 8, 624, DateTimeKind.Local).AddTicks(1297), "#001", "Group 1", false, new DateTime(2022, 8, 27, 15, 39, 8, 624, DateTimeKind.Local).AddTicks(1331) });

            migrationBuilder.InsertData(
                table: "ProductGroup",
                columns: new[] { "Id", "CreatedOn", "GroupCode", "GroupDescription", "IsDeleted", "UpdatedOn" },
                values: new object[] { 2, new DateTime(2022, 8, 27, 15, 39, 8, 624, DateTimeKind.Local).AddTicks(1337), "#002", "Group 2", false, new DateTime(2022, 8, 27, 15, 39, 8, 624, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Price", "ProductDescription", "ProductGroupId", "ProductNumber", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 27, 15, 39, 8, 616, DateTimeKind.Local).AddTicks(5299), false, 100L, "Test 1 Description", 1, "#00001", new DateTime(2022, 8, 27, 15, 39, 8, 618, DateTimeKind.Local).AddTicks(9179) },
                    { 2, new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1382), false, 200L, "Test 2 Description", 1, "#00002", new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1394) },
                    { 3, new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1401), false, 300L, "Test 3 Description", 1, "#00003", new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1402) },
                    { 4, new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1406), false, 400L, "Test 4 Description", 2, "#00004", new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1410) },
                    { 5, new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1414), false, 500L, "Test 5 Description", 2, "#00005", new DateTime(2022, 8, 27, 15, 39, 8, 619, DateTimeKind.Local).AddTicks(1416) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_GroupCode",
                table: "ProductGroup",
                column: "GroupCode",
                unique: true,
                filter: "[GroupCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductNumber",
                table: "Product",
                column: "ProductNumber",
                unique: true,
                filter: "[ProductNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_GroupCode",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductNumber",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductGroup",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductGroup",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "GroupCode",
                table: "ProductGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductNumber",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
