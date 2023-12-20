using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplicationMVC1.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tgroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tproperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tproperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tproperties_Tgroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Tgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentGroupId = table.Column<int>(type: "integer", nullable: false),
                    ChildGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trelations_Tgroups_ChildGroupId",
                        column: x => x.ChildGroupId,
                        principalTable: "Tgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trelations_Tgroups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "Tgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tproperties_GroupId",
                table: "Tproperties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Trelations_ChildGroupId",
                table: "Trelations",
                column: "ChildGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Trelations_ParentGroupId",
                table: "Trelations",
                column: "ParentGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tproperties");

            migrationBuilder.DropTable(
                name: "Trelations");

            migrationBuilder.DropTable(
                name: "Tgroups");
        }
    }
}
