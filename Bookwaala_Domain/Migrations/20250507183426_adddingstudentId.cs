using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookwaala_Domain.Migrations
{
    /// <inheritdoc />
    public partial class adddingstudentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "BookAssignments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookAssignments_StudentId",
                table: "BookAssignments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAssignments_Students_StudentId",
                table: "BookAssignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAssignments_Students_StudentId",
                table: "BookAssignments");

            migrationBuilder.DropIndex(
                name: "IX_BookAssignments_StudentId",
                table: "BookAssignments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BookAssignments");
        }
    }
}
