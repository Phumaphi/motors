using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class removedFeatureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Features");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModelId",
                value: 1);
        }
    }
}
