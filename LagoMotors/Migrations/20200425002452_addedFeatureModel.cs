using Microsoft.EntityFrameworkCore.Migrations;

namespace LagoMotors.Migrations
{
    public partial class addedFeatureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Models_ModelId",
                table: "Feature");

            migrationBuilder.DropIndex(
                name: "IX_Feature_ModelId",
                table: "Feature");

            migrationBuilder.CreateTable(
                name: "FeatureModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureModels_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureModels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureModels_FeatureId",
                table: "FeatureModels",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureModels_ModelId",
                table: "FeatureModels",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureModels");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_ModelId",
                table: "Feature",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Models_ModelId",
                table: "Feature",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
