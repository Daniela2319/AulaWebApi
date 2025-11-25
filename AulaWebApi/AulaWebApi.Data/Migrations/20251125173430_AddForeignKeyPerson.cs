using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AulaWebApi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");
        }
    }
}
