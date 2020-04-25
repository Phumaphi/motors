using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "BMW" },
                    { 3, "Audi" },
                    { 4, "Mercedese Benz" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Corolla" },
                    { 2, 1, "Staurt" },
                    { 3, 1, "Hilux" },
                    { 4, 2, " BMW_i8" },
                    { 5, 2, " BMW_x5" },
                    { 6, 3, "Q8" },
                    { 7, 4, "C-Class" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[,]
                {
                    { 3, 1, "Baby Seat" },
                    { 4, 1, "Power Steering" },
                    { 1, 2, "AirBag" },
                    { 2, 2, "Breaks Lights" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
