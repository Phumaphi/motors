using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class addedFeatureModelCompositeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureModels",
                table: "FeatureModels");

            migrationBuilder.DropIndex(
                name: "IX_FeatureModels_ModelId",
                table: "FeatureModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FeatureModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureModels",
                table: "FeatureModels",
                columns: new[] { "ModelId", "FeatureId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureModels",
                table: "FeatureModels");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FeatureModels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureModels",
                table: "FeatureModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureModels_ModelId",
                table: "FeatureModels",
                column: "ModelId");
        }
    }
}
