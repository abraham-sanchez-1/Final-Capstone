using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class AddedKeyBackToProjectMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectMembers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMembers",
                table: "ProjectMembers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aef9b31e-9d3a-46d3-84f0-562daaf2268c", "085b4596-8cbd-46b7-9246-6bc55f070628", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d67a75c8-5ba6-49b6-a765-466d4b2312c5", "e99d6820-8534-4360-9117-7d5be3936c5e", "Other", "OTHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMembers",
                table: "ProjectMembers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef9b31e-9d3a-46d3-84f0-562daaf2268c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67a75c8-5ba6-49b6-a765-466d4b2312c5");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectMembers");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryTechnology",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df3e39e8-f9a6-4baa-814e-f8614042b11a", "d32d918a-9aff-49d8-bf0a-5a8917220a90", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d371e0c1-b78f-4347-8259-6ac578a5fbec", "6b4b8659-6299-4421-b7e2-46d9965ce4db", "Other", "OTHER" });
        }
    }
}
