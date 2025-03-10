using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunningJap.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelCar1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelCar_Brand_Brand",
                table: "ModelCar");

            migrationBuilder.DropIndex(
                name: "IX_ModelCar_Brand",
                table: "ModelCar");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ModelCar");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelCar_Brand_Id_Brand",
                table: "ModelCar");

            migrationBuilder.DropIndex(
                name: "IX_ModelCar_Id_Brand",
                table: "ModelCar");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "ModelCar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelCar_Brand",
                table: "ModelCar",
                column: "Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelCar_Brand_Brand",
                table: "ModelCar",
                column: "Brand",
                principalTable: "Brand",
                principalColumn: "Id");
        }
    }
}
