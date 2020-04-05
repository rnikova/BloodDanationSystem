namespace BloodDanationSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DonorsPatientsAddIsDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DonorsPatients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DonorsPatients");
        }
    }
}
