namespace BloodDanationSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCityToDonorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Donors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_CityId",
                table: "Donors",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Cities_CityId",
                table: "Donors",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Cities_CityId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_CityId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Donors");
        }
    }
}
