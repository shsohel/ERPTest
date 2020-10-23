using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPTest.Migrations
{
    public partial class SecoSFSnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_BuyerContactInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos");

            migrationBuilder.DropColumn(
                name: "BuyerPersonalInfoId",
                table: "BuyerContactInfos");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "BuyerContactInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerContactInfos_BuyerId",
                table: "BuyerContactInfos",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerId",
                table: "BuyerContactInfos",
                column: "BuyerId",
                principalTable: "BuyerPersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerId",
                table: "BuyerContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_BuyerContactInfos_BuyerId",
                table: "BuyerContactInfos");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "BuyerContactInfos");

            migrationBuilder.AddColumn<int>(
                name: "BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerContactInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                column: "BuyerPersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                column: "BuyerPersonalInfoId",
                principalTable: "BuyerPersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
