using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPTest.Migrations
{
    public partial class Fitfth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "BuyerContactInfos");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                column: "BuyerPersonalInfoId",
                principalTable: "BuyerPersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "BuyerContactInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerContactInfos_BuyerPersonalInfos_BuyerPersonalInfoId",
                table: "BuyerContactInfos",
                column: "BuyerPersonalInfoId",
                principalTable: "BuyerPersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
