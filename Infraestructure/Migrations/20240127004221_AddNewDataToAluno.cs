using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDataToAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Alunos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusPagamentoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPagamento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PlanoId",
                table: "Alunos",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_StatusPagamentoId",
                table: "Alunos",
                column: "StatusPagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Planos_PlanoId",
                table: "Alunos",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_StatusPagamento_StatusPagamentoId",
                table: "Alunos",
                column: "StatusPagamentoId",
                principalTable: "StatusPagamento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Planos_PlanoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_StatusPagamento_StatusPagamentoId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "StatusPagamento");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_PlanoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_StatusPagamentoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "StatusPagamentoId",
                table: "Alunos");
        }
    }
}
