using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePagamentoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pagamentos_PagamentoId",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_PagamentoId",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "PagamentoId",
                table: "Pagamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PagamentoId",
                table: "Pagamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PagamentoId",
                table: "Pagamentos",
                column: "PagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pagamentos_PagamentoId",
                table: "Pagamentos",
                column: "PagamentoId",
                principalTable: "Pagamentos",
                principalColumn: "Id");
        }
    }
}
