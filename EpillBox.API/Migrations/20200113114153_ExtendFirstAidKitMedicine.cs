using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class ExtendFirstAidKitMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstServingAt",
                table: "FirstAidKitMedicines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfServings",
                table: "FirstAidKitMedicines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServingSize",
                table: "FirstAidKitMedicines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstServingAt",
                table: "FirstAidKitMedicines");

            migrationBuilder.DropColumn(
                name: "NumberOfServings",
                table: "FirstAidKitMedicines");

            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "FirstAidKitMedicines");
        }
    }
}
