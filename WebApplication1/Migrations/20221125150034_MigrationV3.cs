using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Poll",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Are you a programmer?" },
                    { 2, "Do you like dogs?" },
                    { 3, "Do you like coffee?" }
                });

            migrationBuilder.InsertData(
                table: "VoteOption",
                columns: new[] { "Id", "PollId", "Title", "VoteAmount" },
                values: new object[,]
                {
                    { 1, 1, "yes", 5 },
                    { 2, 1, "no", 2 },
                    { 3, 1, "ofcourse!", 8 },
                    { 4, 2, "yes sirr", 28 },
                    { 5, 2, "no i like turtles", 10 },
                    { 6, 2, "ofcourse i do!", 5 },
                    { 7, 3, "YES", 50 },
                    { 8, 3, "NO", 14 },
                    { 9, 3, "I'm addicted to it!", 75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VoteOption",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Poll",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Poll",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Poll",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
