using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mercado.NET.Web.Ui.Data.Migrations
{
    public partial class AddProdutoAndProdutoPrecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Inclusao = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoPrecos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPrecos_ProdutoId",
                table: "ProdutoPrecos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoPrecos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
