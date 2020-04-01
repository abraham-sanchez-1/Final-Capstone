using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class AddedDeveloperIdToReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef9b31e-9d3a-46d3-84f0-562daaf2268c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67a75c8-5ba6-49b6-a765-466d4b2312c5");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "689a7268-2519-4996-a74c-8892efce8716", "836dd53b-6d49-4599-a9e7-f965e1610036", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d8fb946-1501-4cc4-9f13-4e5506734a68", "a8fe1135-9f99-4194-a2cb-8805fe17bee6", "Other", "OTHER" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DeveloperId",
                table: "Reviews",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Developers_DeveloperId",
                table: "Reviews",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Developers_DeveloperId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DeveloperId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689a7268-2519-4996-a74c-8892efce8716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d8fb946-1501-4cc4-9f13-4e5506734a68");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aef9b31e-9d3a-46d3-84f0-562daaf2268c", "085b4596-8cbd-46b7-9246-6bc55f070628", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d67a75c8-5ba6-49b6-a765-466d4b2312c5", "e99d6820-8534-4360-9117-7d5be3936c5e", "Other", "OTHER" });
        }
    }
}
