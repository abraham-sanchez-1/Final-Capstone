using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class ChangeDbSetNameAndRemovedDeveloperTypeFromDeveloperModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleOpenings_Projects_ProjectId",
                table: "RoleOpenings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleOpenings_RoleTypes_RoleId",
                table: "RoleOpenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleOpenings",
                table: "RoleOpenings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88871305-2356-439f-bf85-5182100e2b2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "facbfdef-b2b1-4931-8f3d-42ab84772ab1");

            migrationBuilder.DropColumn(
                name: "DeveloperType",
                table: "Developers");

            migrationBuilder.RenameTable(
                name: "RoleOpenings",
                newName: "Openings");

            migrationBuilder.RenameIndex(
                name: "IX_RoleOpenings_RoleId",
                table: "Openings",
                newName: "IX_Openings_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleOpenings_ProjectId",
                table: "Openings",
                newName: "IX_Openings_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Openings",
                table: "Openings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d256c9d9-7c96-4acb-bd9f-b1e9c57d81d0", "2c1f2190-6214-4fcb-ad74-52352ff4e349", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "942e5d1b-dd2d-46e8-a830-e37a52a04e7b", "20d3ddcd-ec14-4a33-b876-c1c0c912d2fd", "Other", "OTHER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Openings_Projects_ProjectId",
                table: "Openings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Openings_RoleTypes_RoleId",
                table: "Openings",
                column: "RoleId",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Openings_Projects_ProjectId",
                table: "Openings");

            migrationBuilder.DropForeignKey(
                name: "FK_Openings_RoleTypes_RoleId",
                table: "Openings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Openings",
                table: "Openings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "942e5d1b-dd2d-46e8-a830-e37a52a04e7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d256c9d9-7c96-4acb-bd9f-b1e9c57d81d0");

            migrationBuilder.RenameTable(
                name: "Openings",
                newName: "RoleOpenings");

            migrationBuilder.RenameIndex(
                name: "IX_Openings_RoleId",
                table: "RoleOpenings",
                newName: "IX_RoleOpenings_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Openings_ProjectId",
                table: "RoleOpenings",
                newName: "IX_RoleOpenings_ProjectId");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperType",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleOpenings",
                table: "RoleOpenings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88871305-2356-439f-bf85-5182100e2b2c", "5942c3b3-9782-48e9-a7a3-b548968e3eeb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "facbfdef-b2b1-4931-8f3d-42ab84772ab1", "97ff1315-72b9-4a1b-9744-e770040c0f56", "Other", "OTHER" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleOpenings_Projects_ProjectId",
                table: "RoleOpenings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleOpenings_RoleTypes_RoleId",
                table: "RoleOpenings",
                column: "RoleId",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
