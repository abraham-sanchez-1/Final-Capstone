using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class AddedTableForPendingApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "942e5d1b-dd2d-46e8-a830-e37a52a04e7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d256c9d9-7c96-4acb-bd9f-b1e9c57d81d0");

            migrationBuilder.AddColumn<string>(
                name: "GithubUrl",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlPicture",
                table: "Developers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f2017e8-24c3-4c86-86c9-6a377d110fce", "03b85aea-03cf-4007-ab1a-fcbbe98f44ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7629a4ef-abf2-4f10-bf37-1d10902b2b37", "96a9054e-7b18-4ed7-8dd9-6f51a6c5e04f", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f2017e8-24c3-4c86-86c9-6a377d110fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7629a4ef-abf2-4f10-bf37-1d10902b2b37");

            migrationBuilder.DropColumn(
                name: "GithubUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UrlPicture",
                table: "Developers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d256c9d9-7c96-4acb-bd9f-b1e9c57d81d0", "2c1f2190-6214-4fcb-ad74-52352ff4e349", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "942e5d1b-dd2d-46e8-a830-e37a52a04e7b", "20d3ddcd-ec14-4a33-b876-c1c0c912d2fd", "Other", "OTHER" });
        }
    }
}
