using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualProjectCapstone.Migrations
{
    public partial class AddedDbSetToIncludeLatestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f2017e8-24c3-4c86-86c9-6a377d110fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7629a4ef-abf2-4f10-bf37-1d10902b2b37");

            migrationBuilder.CreateTable(
                name: "PendingApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(nullable: false),
                    OpeningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingApplications_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PendingApplications_Openings_OpeningId",
                        column: x => x.OpeningId,
                        principalTable: "Openings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f93e28cb-3276-474f-8bc3-e952a3f00404", "941bebeb-7113-43a7-bbd6-3d22ff38db9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd732602-050d-4fcb-9c76-b4a135db5814", "9d7657c2-a396-4e69-a499-0a5a2c7c341a", "Other", "OTHER" });

            migrationBuilder.CreateIndex(
                name: "IX_PendingApplications_DeveloperId",
                table: "PendingApplications",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingApplications_OpeningId",
                table: "PendingApplications",
                column: "OpeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PendingApplications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd732602-050d-4fcb-9c76-b4a135db5814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93e28cb-3276-474f-8bc3-e952a3f00404");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f2017e8-24c3-4c86-86c9-6a377d110fce", "03b85aea-03cf-4007-ab1a-fcbbe98f44ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7629a4ef-abf2-4f10-bf37-1d10902b2b37", "96a9054e-7b18-4ed7-8dd9-6f51a6c5e04f", "Other", "OTHER" });
        }
    }
}
