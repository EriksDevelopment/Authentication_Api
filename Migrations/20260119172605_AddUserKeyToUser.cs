using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserKeyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserKey",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserKey",
                table: "User",
                column: "UserKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserKey",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "User");
        }
    }
}
