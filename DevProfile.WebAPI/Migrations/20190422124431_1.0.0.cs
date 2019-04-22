using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevProfile.WebAPI.Migrations
{
    public partial class _100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "devprofile");

            migrationBuilder.CreateTable(
                name: "Developer",
                schema: "devprofile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stack",
                schema: "devprofile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technology",
                schema: "devprofile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "devprofile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TechnologyId = table.Column<int>(nullable: false),
                    StackId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "devprofile",
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_Stack_StackId",
                        column: x => x.StackId,
                        principalSchema: "devprofile",
                        principalTable: "Stack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalSchema: "devprofile",
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_DeveloperId",
                schema: "devprofile",
                table: "Skill",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_StackId",
                schema: "devprofile",
                table: "Skill",
                column: "StackId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TechnologyId",
                schema: "devprofile",
                table: "Skill",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill",
                schema: "devprofile");

            migrationBuilder.DropTable(
                name: "Developer",
                schema: "devprofile");

            migrationBuilder.DropTable(
                name: "Stack",
                schema: "devprofile");

            migrationBuilder.DropTable(
                name: "Technology",
                schema: "devprofile");
        }
    }
}
