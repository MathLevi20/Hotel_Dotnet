using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotel.Migrations
{
    public partial class hotelv02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parceiro_Pessoa_juridicaId",
                table: "parceiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_parceiro_ParceiroId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaHotel_Pessoa_FisicaId",
                table: "reservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservaHotel",
                table: "reservaHotel");

            migrationBuilder.DropIndex(
                name: "IX_reservaHotel_FisicaId",
                table: "reservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parceiro",
                table: "parceiro");

            migrationBuilder.DropIndex(
                name: "IX_parceiro_juridicaId",
                table: "parceiro");

            migrationBuilder.DropColumn(
                name: "FisicaId",
                table: "reservaHotel");

            migrationBuilder.DropColumn(
                name: "juridicaId",
                table: "parceiro");

            migrationBuilder.RenameTable(
                name: "reservaHotel",
                newName: "ReservaHotel");

            migrationBuilder.RenameTable(
                name: "parceiro",
                newName: "Parceiro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parceiro",
                table: "Parceiro",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FisicaReservaHotel",
                columns: table => new
                {
                    FisicaId = table.Column<int>(type: "integer", nullable: false),
                    ReservaHotelid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisicaReservaHotel", x => new { x.FisicaId, x.ReservaHotelid });
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_Pessoa_FisicaId",
                        column: x => x.FisicaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_ReservaHotel_ReservaHotelid",
                        column: x => x.ReservaHotelid,
                        principalTable: "ReservaHotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuridicaParceiro",
                columns: table => new
                {
                    JuridicaId = table.Column<int>(type: "integer", nullable: false),
                    ParceiroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicaParceiro", x => new { x.JuridicaId, x.ParceiroId });
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Pessoa_JuridicaId",
                        column: x => x.JuridicaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FisicaReservaHotel_ReservaHotelid",
                table: "FisicaReservaHotel",
                column: "ReservaHotelid");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicaParceiro_ParceiroId",
                table: "JuridicaParceiro",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Parceiro_ParceiroId",
                table: "Pessoa",
                column: "ParceiroId",
                principalTable: "Parceiro",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Parceiro_ParceiroId",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "FisicaReservaHotel");

            migrationBuilder.DropTable(
                name: "JuridicaParceiro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parceiro",
                table: "Parceiro");

            migrationBuilder.RenameTable(
                name: "ReservaHotel",
                newName: "reservaHotel");

            migrationBuilder.RenameTable(
                name: "Parceiro",
                newName: "parceiro");

            migrationBuilder.AddColumn<int>(
                name: "FisicaId",
                table: "reservaHotel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "juridicaId",
                table: "parceiro",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservaHotel",
                table: "reservaHotel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parceiro",
                table: "parceiro",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_reservaHotel_FisicaId",
                table: "reservaHotel",
                column: "FisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_parceiro_juridicaId",
                table: "parceiro",
                column: "juridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_parceiro_Pessoa_juridicaId",
                table: "parceiro",
                column: "juridicaId",
                principalTable: "Pessoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_parceiro_ParceiroId",
                table: "Pessoa",
                column: "ParceiroId",
                principalTable: "parceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaHotel_Pessoa_FisicaId",
                table: "reservaHotel",
                column: "FisicaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }
    }
}
