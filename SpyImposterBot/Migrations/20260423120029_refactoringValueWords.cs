using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class refactoringValueWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 156L,
                column: "word",
                value: "Летувинский ловкач");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 156L,
                column: "word",
                value: "Летувинский ловкая");
        }
    }
}
