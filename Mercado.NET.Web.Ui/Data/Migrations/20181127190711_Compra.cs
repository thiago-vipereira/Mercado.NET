using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mercado.NET.Web.Ui.Data.Migrations
{
    public partial class Compra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompraId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CompraId",
                table: "Produtos",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Compra_CompraId",
                table: "Produtos",
                column: "CompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Compra_CompraId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CompraId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Produtos");
        }
    }
}
