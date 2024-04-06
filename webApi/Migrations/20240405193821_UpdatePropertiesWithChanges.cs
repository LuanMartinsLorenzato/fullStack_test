using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertiesWithChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "tb_user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "tb_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tb_user",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "tb_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "tb_user",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_user",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "tb_user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tb_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "tb_user",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_user",
                newName: "id");
        }
    }
}
