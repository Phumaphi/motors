using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class SeedingFeatureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FeatureModels",
                columns: new[] { "ModelId", "FeatureId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 5, 4 },
                    { 2, 3 },
                    { 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "FeatureModels",
                keyColumns: new[] { "ModelId", "FeatureId" },
                keyValues: new object[] { 5, 4 });
        }
    }
}
