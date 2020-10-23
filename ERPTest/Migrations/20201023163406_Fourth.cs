using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPTest.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
