using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteAeC.Migrations
{
    /// <inheritdoc />
    public partial class Primeiramigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroporto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIcao = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PressaoAtmosferica = table.Column<int>(type: "int", nullable: false),
                    Visibilidade = table.Column<string>(type: "VARCHAR(7)", nullable: false),
                    Vento = table.Column<int>(type: "int", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false),
                    Umidade = table.Column<int>(type: "int", nullable: false),
                    Condicao = table.Column<string>(type: "CHAR(2)", nullable: false),
                    CondicaoDesc = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Temp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroporto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IndiceUv = table.Column<int>(type: "int", nullable: false),
                    CondicaoDesc = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clima_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_aeroporto_codigo",
                table: "Aeroporto",
                column: "CodigoIcao");

            migrationBuilder.CreateIndex(
                name: "idx_localidade_cidade",
                table: "Cidade",
                column: "NomeCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Clima_CidadeId",
                table: "Clima",
                column: "CidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeroporto");

            migrationBuilder.DropTable(
                name: "Clima");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
