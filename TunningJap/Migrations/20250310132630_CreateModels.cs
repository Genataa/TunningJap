using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunningJap.Migrations
{
    /// <inheritdoc />
    public partial class CreateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelCar_Brand_BrandNameId",
                table: "ModelCar");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Category_CategoryNameId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Model_ModelCar_ModelCarId",
                table: "Parts_Model");

            migrationBuilder.DropTable(
                name: "testModel");

            migrationBuilder.DropIndex(
                name: "IX_Parts_Model_ModelCarId",
                table: "Parts_Model");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CategoryNameId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_ModelCar_BrandNameId",
                table: "ModelCar");

            migrationBuilder.DropColumn(
                name: "ModelCarId",
                table: "Parts_Model");

            migrationBuilder.DropColumn(
                name: "CategoryNameId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "BrandNameId",
                table: "ModelCar");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Model_ID_model",
                table: "Parts_Model",
                column: "ID_model");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Model_ID_Parts",
                table: "Parts_Model",
                column: "ID_Parts");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_IDCategory",
                table: "Parts",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCar_Id_Brand",
                table: "ModelCar",
                column: "Id_Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelCar_Brand_Id_Brand",
                table: "ModelCar",
                column: "Id_Brand",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Category_IDCategory",
                table: "Parts",
                column: "IDCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Model_ModelCar_ID_model",
                table: "Parts_Model",
                column: "ID_model",
                principalTable: "ModelCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Model_Parts_ID_Parts",
                table: "Parts_Model",
                column: "ID_Parts",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelCar_Brand_Id_Brand",
                table: "ModelCar");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Category_IDCategory",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Model_ModelCar_ID_model",
                table: "Parts_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Model_Parts_ID_Parts",
                table: "Parts_Model");

            migrationBuilder.DropIndex(
                name: "IX_Parts_Model_ID_model",
                table: "Parts_Model");

            migrationBuilder.DropIndex(
                name: "IX_Parts_Model_ID_Parts",
                table: "Parts_Model");

            migrationBuilder.DropIndex(
                name: "IX_Parts_IDCategory",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_ModelCar_Id_Brand",
                table: "ModelCar");

            migrationBuilder.AddColumn<int>(
                name: "ModelCarId",
                table: "Parts_Model",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryNameId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandNameId",
                table: "ModelCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "testModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Model_ModelCarId",
                table: "Parts_Model",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CategoryNameId",
                table: "Parts",
                column: "CategoryNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCar_BrandNameId",
                table: "ModelCar",
                column: "BrandNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelCar_Brand_BrandNameId",
                table: "ModelCar",
                column: "BrandNameId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Category_CategoryNameId",
                table: "Parts",
                column: "CategoryNameId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Model_ModelCar_ModelCarId",
                table: "Parts_Model",
                column: "ModelCarId",
                principalTable: "ModelCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
