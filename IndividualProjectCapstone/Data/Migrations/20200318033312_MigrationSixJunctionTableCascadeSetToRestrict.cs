using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Data.Migrations
{
    public partial class MigrationSixJunctionTableCascadeSetToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7401c26-c946-41bd-be90-bfb15ab90c89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5b57836-56a5-4a54-b6f4-469480f58184");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d7ce7ad-c0be-4a83-bfe9-d5357fc4b2a3", "9affa020-052a-4574-8bfe-f2a6a24635d5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ca519af-10aa-4996-ac6b-e9cddca65e08", "d6886645-6cc2-43fc-a693-f5919746e8e5", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d7ce7ad-c0be-4a83-bfe9-d5357fc4b2a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca519af-10aa-4996-ac6b-e9cddca65e08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7401c26-c946-41bd-be90-bfb15ab90c89", "4b6c0244-c81d-4525-a957-fe05dfb5058d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5b57836-56a5-4a54-b6f4-469480f58184", "6e20ce39-106d-4761-aeb8-9e65d48acd42", "Other", "OTHER" });
        }
    }
}
