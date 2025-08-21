using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISpire.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class permissions_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Permissions",
                table: "Accounts",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "Accounts");
        }
    }
}
