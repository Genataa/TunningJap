using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunningJap.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_PartsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_model = table.Column<int>(type: "int", nullable: false),
                    ModelCarId = table.Column<int>(type: "int", nullable: false),
                    ID_Parts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Model_ModelCar_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Model_ModelCarId",
                table: "Parts_Model",
                column: "ModelCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts_Model");
        }
    }
}
