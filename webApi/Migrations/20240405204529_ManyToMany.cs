using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_movie_tb_user_UserId",
                table: "tb_movie");

            migrationBuilder.DropIndex(
                name: "IX_tb_movie_UserId",
                table: "tb_movie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_movie");

            migrationBuilder.CreateTable(
                name: "tb_movie_user",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movie_user", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_tb_movie_user_tb_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tb_movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_movie_user_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_user_MovieId",
                table: "tb_movie_user",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_movie_user");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "tb_movie",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_UserId",
                table: "tb_movie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_movie_tb_user_UserId",
                table: "tb_movie",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
