using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinav.Data.Migrations
{
    /// <inheritdoc />
    public partial class supplierModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblUser",
                newName: "TblUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUser",
                table: "TblUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TblSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSupplier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUser",
                table: "TblUser");

            migrationBuilder.RenameTable(
                name: "TblUser",
                newName: "tblUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser",
                column: "Id");
        }
    }
}
