using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hotel.Migrations
{
    public partial class hotelv01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipopessoa = table.Column<string>(type: "text", nullable: false),
                    atividade = table.Column<string>(type: "text", nullable: false),
                    juridicaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Fone = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rg = table.Column<string>(type: "text", nullable: true),
                    genero = table.Column<string>(type: "text", nullable: true),
                    nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ParceiroId = table.Column<int>(type: "integer", nullable: true),
                    cnpj = table.Column<string>(type: "text", nullable: true),
                    inscricaoestadual = table.Column<string>(type: "text", nullable: true),
                    fundacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservaHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numeroreserva = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<int>(type: "integer", nullable: false),
                    datareserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FisicaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservaHotel_Pessoa_FisicaId",
                        column: x => x.FisicaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_parceiro_juridicaId",
                table: "parceiro",
                column: "juridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ParceiroId",
                table: "Pessoa",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_reservaHotel_FisicaId",
                table: "reservaHotel",
                column: "FisicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_parceiro_Pessoa_juridicaId",
                table: "parceiro",
                column: "juridicaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parceiro_Pessoa_juridicaId",
                table: "parceiro");

            migrationBuilder.DropTable(
                name: "reservaHotel");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "parceiro");
        }
    }
}
