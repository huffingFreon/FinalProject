using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.ProfessorID);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    SoftwareID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    CSOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.SoftwareID);
                });

            migrationBuilder.CreateTable(
                name: "CSSystems",
                columns: table => new
                {
                    CSSystemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    PrimaryUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSSystems", x => x.CSSystemID);
                    table.ForeignKey(
                        name: "FK_CSSystems_Professors_PrimaryUserID",
                        column: x => x.PrimaryUserID,
                        principalTable: "Professors",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemID);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Professors_UserID",
                        column: x => x.UserID,
                        principalTable: "Professors",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSoftware",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false),
                    SoftwareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSoftware", x => new { x.ProfessorID, x.SoftwareID });
                    table.ForeignKey(
                        name: "FK_ProfessorSoftware_Professors_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professors",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSoftware_Software_SoftwareID",
                        column: x => x.SoftwareID,
                        principalTable: "Software",
                        principalColumn: "SoftwareID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemSoftware",
                columns: table => new
                {
                    CSSystemID = table.Column<int>(nullable: false),
                    SoftwareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSoftware", x => new { x.CSSystemID, x.SoftwareID });
                    table.ForeignKey(
                        name: "FK_SystemSoftware_CSSystems_CSSystemID",
                        column: x => x.CSSystemID,
                        principalTable: "CSSystems",
                        principalColumn: "CSSystemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemSoftware_Software_SoftwareID",
                        column: x => x.SoftwareID,
                        principalTable: "Software",
                        principalColumn: "SoftwareID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSSystems_PrimaryUserID",
                table: "CSSystems",
                column: "PrimaryUserID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_UserID",
                table: "InventoryItems",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSoftware_SoftwareID",
                table: "ProfessorSoftware",
                column: "SoftwareID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSoftware_SoftwareID",
                table: "SystemSoftware",
                column: "SoftwareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "ProfessorSoftware");

            migrationBuilder.DropTable(
                name: "SystemSoftware");

            migrationBuilder.DropTable(
                name: "CSSystems");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
