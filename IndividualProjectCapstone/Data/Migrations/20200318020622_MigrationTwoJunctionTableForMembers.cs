using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Data.Migrations
{
    public partial class MigrationTwoJunctionTableForMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_DeveloperId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6288016f-0622-4b5a-9de0-c5b1a6a40521");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c07959f-fa55-4e1c-ae5e-d9c7d523d3a4");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectLead",
                table: "ProjectMembers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77313195-d05c-407f-a315-e2f9f5308fa8", "060cc559-7ba0-448f-9d21-81f49a712b8b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b26208ef-c004-4fa4-9038-2bdc90d9f298", "1d3652d9-6818-4095-a1ef-e9a0f09e4ad7", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77313195-d05c-407f-a315-e2f9f5308fa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b26208ef-c004-4fa4-9038-2bdc90d9f298");

            migrationBuilder.DropColumn(
                name: "IsProjectLead",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6288016f-0622-4b5a-9de0-c5b1a6a40521", "dfa025e8-e3f5-450a-911d-91dfc9df602e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c07959f-fa55-4e1c-ae5e-d9c7d523d3a4", "06cc041d-4943-4d98-bc21-cc91c5c9830a", "Other", "OTHER" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_DeveloperId",
                table: "Projects",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
