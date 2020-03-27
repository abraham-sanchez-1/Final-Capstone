using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class RemovedRequiredFromSecondaryTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b9b1c2-037d-4c17-a16e-fcff5f23f64d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d13cee06-bb01-43e9-aeab-03fb8a35b970");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryTechnology",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df3e39e8-f9a6-4baa-814e-f8614042b11a", "d32d918a-9aff-49d8-bf0a-5a8917220a90", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d371e0c1-b78f-4347-8259-6ac578a5fbec", "6b4b8659-6299-4421-b7e2-46d9965ce4db", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d371e0c1-b78f-4347-8259-6ac578a5fbec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df3e39e8-f9a6-4baa-814e-f8614042b11a");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryTechnology",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d13cee06-bb01-43e9-aeab-03fb8a35b970", "76175191-8229-420d-be2f-b60ce5fc3b35", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17b9b1c2-037d-4c17-a16e-fcff5f23f64d", "4bc728a2-e2bf-4d11-b564-f78c52bdb6ca", "Other", "OTHER" });
        }
    }
}
