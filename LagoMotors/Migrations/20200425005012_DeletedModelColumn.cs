using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class DeletedModelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Feature");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Feature",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelId",
                value: 1);
        }
    }
}
