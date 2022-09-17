using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class fixed_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisctrictId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CityId",
                table: "Plants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_DisctrictId",
                table: "Plants",
                column: "DisctrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Citys_CityId",
                table: "Plants",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Districts_DisctrictId",
                table: "Plants",
                column: "DisctrictId",
                principalTable: "Districts",
                principalColumn: "Id" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Citys_CityId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Districts_DisctrictId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_CityId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_DisctrictId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DisctrictId",
                table: "Plants");
        }
    }
}
