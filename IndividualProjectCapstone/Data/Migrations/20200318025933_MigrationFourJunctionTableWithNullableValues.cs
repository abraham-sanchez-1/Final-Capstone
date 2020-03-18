using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Data.Migrations
{
    public partial class MigrationFourJunctionTableWithNullableValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_Developers_UserId",
                table: "ProjectMembers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectMembers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec0cf42-f6ad-42b1-9188-4b13d55d7a7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f64f6b-05f9-4c90-8df5-b29e4a302c6f");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "ProjectMembers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f66460bb-ad61-4d0b-9245-88681ed64670", "9c32a9d3-a709-49b8-a55a-fc342a46e22d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb17c544-7d58-4f85-af45-be8f5ab969a9", "1c042530-90bd-4c74-8c31-e40638c55c18", "Other", "OTHER" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_DeveloperId",
                table: "ProjectMembers",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_Developers_DeveloperId",
                table: "ProjectMembers",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_Developers_DeveloperId",
                table: "ProjectMembers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMembers_DeveloperId",
                table: "ProjectMembers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb17c544-7d58-4f85-af45-be8f5ab969a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f66460bb-ad61-4d0b-9245-88681ed64670");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProjectMembers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53f64f6b-05f9-4c90-8df5-b29e4a302c6f", "f9ce7415-47f5-49e4-9655-23a6a1c92a7e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ec0cf42-f6ad-42b1-9188-4b13d55d7a7c", "ee0018ae-c9a7-4134-a4e5-d6367ed265dd", "Other", "OTHER" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_Developers_UserId",
                table: "ProjectMembers",
                column: "UserId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
