using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressStart2.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaDbSet_Cliente_ClienteId",
                table: "VendaDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaItemDbSet_VendaDbSet_VendaId",
                table: "VendaItemDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendaDbSet",
                table: "VendaDbSet");

            migrationBuilder.RenameTable(
                name: "VendaDbSet",
                newName: "Venda");

            migrationBuilder.RenameIndex(
                name: "IX_VendaDbSet_ClienteId",
                table: "Venda",
                newName: "IX_Venda_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItemDbSet_Venda_VendaId",
                table: "VendaItemDbSet",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaItemDbSet_Venda_VendaId",
                table: "VendaItemDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "VendaDbSet");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ClienteId",
                table: "VendaDbSet",
                newName: "IX_VendaDbSet_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendaDbSet",
                table: "VendaDbSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaDbSet_Cliente_ClienteId",
                table: "VendaDbSet",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItemDbSet_VendaDbSet_VendaId",
                table: "VendaItemDbSet",
                column: "VendaId",
                principalTable: "VendaDbSet",
                principalColumn: "Id");
        }
    }
}
