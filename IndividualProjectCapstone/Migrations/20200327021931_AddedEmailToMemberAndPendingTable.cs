using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class AddedEmailToMemberAndPendingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd732602-050d-4fcb-9c76-b4a135db5814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93e28cb-3276-474f-8bc3-e952a3f00404");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryTechnology",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GithubUrl",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProjectMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PendingApplications",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d13cee06-bb01-43e9-aeab-03fb8a35b970", "76175191-8229-420d-be2f-b60ce5fc3b35", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17b9b1c2-037d-4c17-a16e-fcff5f23f64d", "4bc728a2-e2bf-4d11-b564-f78c52bdb6ca", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b9b1c2-037d-4c17-a16e-fcff5f23f64d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d13cee06-bb01-43e9-aeab-03fb8a35b970");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProjectMembers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PendingApplications");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryTechnology",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "GithubUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f93e28cb-3276-474f-8bc3-e952a3f00404", "941bebeb-7113-43a7-bbd6-3d22ff38db9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd732602-050d-4fcb-9c76-b4a135db5814", "9d7657c2-a396-4e69-a499-0a5a2c7c341a", "Other", "OTHER" });
        }
    }
}
