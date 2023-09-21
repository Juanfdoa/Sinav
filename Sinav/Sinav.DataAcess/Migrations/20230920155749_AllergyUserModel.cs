using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinav.Data.Migrations
{
    /// <inheritdoc />
    public partial class AllergyUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAllergyUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAllergyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAllergyUser_TblAllergy_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "TblAllergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAllergyUser_TblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAllergyUser_AllergyId",
                table: "TblAllergyUser",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAllergyUser_UserId",
                table: "TblAllergyUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAllergyUser");
        }
    }
}
