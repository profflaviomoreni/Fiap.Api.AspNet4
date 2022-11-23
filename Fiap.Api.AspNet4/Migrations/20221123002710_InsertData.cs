using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Api.AspNet4.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "NomeCategoria" },
                values: new object[,]
                {
                    { 1, "TV" },
                    { 2, "Smartphone" },
                    { 3, "PC" },
                    { 4, "Notebook" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "NomeMarca" },
                values: new object[,]
                {
                    { 1, "LG" },
                    { 2, "Apple" },
                    { 3, "Samsung" },
                    { 4, "Motorola" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "NomeUsuario", "Regra", "Senha" },
                values: new object[,]
                {
                    { 1, "Admin Senior", "Senior", "123456" },
                    { 2, "Admin Pleno", "Pleno", "123456" },
                    { 3, "Admin Junior", "Junior", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Caracteristicas", "CategoriaId", "DataLancamento", "Descricao", "MarcaId", "Nome", "Preco", "Sku" },
                values: new object[,]
                {
                    { 1, "", 2, new DateTime(2022, 11, 22, 21, 27, 10, 171, DateTimeKind.Local).AddTicks(1587), "Apple iPhone 12", 2, "iPhone 12 mini", 5000m, "SKUIPH12" },
                    { 2, "", 2, new DateTime(2022, 11, 22, 21, 27, 10, 171, DateTimeKind.Local).AddTicks(1611), "Apple iPhone 11", 2, "iPhone 11", 11000m, "SKUIPH11" },
                    { 3, "", 2, new DateTime(2022, 11, 22, 21, 27, 10, 171, DateTimeKind.Local).AddTicks(1612), "Apple iPhone 12", 2, "iPhone 12", 12000m, "SKUIPH12" },
                    { 4, "", 2, new DateTime(2022, 11, 22, 21, 27, 10, 171, DateTimeKind.Local).AddTicks(1613), "Apple iPhone 13", 2, "iPhone 13", 13000m, "SKUIPH13" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 2);
        }
    }
}
