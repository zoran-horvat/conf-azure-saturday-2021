using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedProductReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "Content",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: "5D1C71A1-2723-4FB6-B067-66F3BF5D0B60");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: "910500A0-F873-4B12-BFE0-73648AD89929");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Key",
                value: "2231D5B8-264D-4486-BCA3-E94D6FAA9F22");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Key",
                value: "E306E9B6-D5E3-4714-B6BA-082C0F370F81");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Key",
                value: "B2FF8A9E-A177-4929-A546-3BF014250394");

            migrationBuilder.UpdateData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Key",
                value: "B6D1FEF5-9DA2-4DCC-860C-BB07DDF7BF88");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Content",
                table: "Products");
        }
    }
}
