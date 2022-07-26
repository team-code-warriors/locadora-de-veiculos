using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TabelaVeiculoCriada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cambio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(50)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(50)", nullable: false),
                    Kilometragem = table.Column<int>(type: "int", nullable: false),
                    TipoDeCombustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    CapacidadeDoTanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrupoDeVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoDeVeiculos_GrupoDeVeiculosId",
                        column: x => x.GrupoDeVeiculosId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoDeVeiculosId",
                table: "TBVeiculo",
                column: "GrupoDeVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBVeiculo");
        }
    }
}
