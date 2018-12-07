using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mercado.NET.Web.Ui.Data.Migrations
{
    public partial class ProdutoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
