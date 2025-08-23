using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISpire.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class account_permissions_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "AccountPermission",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionName = table.Column<string>(type: "text", nullable: false),
                    AccountGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPermission", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_AccountPermission_Accounts_AccountGuid",
                        column: x => x.AccountGuid,
                        principalTable: "Accounts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPermission_AccountGuid",
                table: "AccountPermission",
                column: "AccountGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPermission");

            migrationBuilder.AddColumn<string[]>(
                name: "Permissions",
                table: "Accounts",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
