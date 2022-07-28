using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AlteracaoTabelaTaxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTaxa");

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id");
        }
    }
}
