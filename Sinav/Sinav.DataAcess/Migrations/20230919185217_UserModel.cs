using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinav.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TblUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "TblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
