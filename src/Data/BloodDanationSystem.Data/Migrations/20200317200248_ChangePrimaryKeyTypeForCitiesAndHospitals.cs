namespace BloodDanationSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangePrimaryKeyTypeForCitiesAndHospitals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodTypeId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId1",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId1",
                table: "Patients",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Hospitals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Hospitals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeId",
                table: "Donors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId1",
                table: "Donors",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BloodTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "BloodCenters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BloodCenters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodTypeId1",
                table: "Patients",
                column: "BloodTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId1",
                table: "Patients",
                column: "HospitalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId1",
                table: "Donors",
                column: "BloodTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId1",
                table: "Donors",
                column: "BloodTypeId1",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId1",
                table: "Patients",
                column: "BloodTypeId1",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId1",
                table: "Patients",
                column: "HospitalId1",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId1",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId1",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodTypeId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId1",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodTypeId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BloodTypeId1",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Hospitals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Hospitals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "BloodTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "BloodCenters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "BloodCenters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodTypeId",
                table: "Patients",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId",
                table: "Patients",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId",
                table: "Patients",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
