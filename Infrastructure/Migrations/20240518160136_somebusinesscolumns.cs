using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonTours.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class somebusinesscolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "Trips",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "FoodMeals",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Trips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Trips",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Inquiries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IdentityImage",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInner",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_HotelId",
                table: "Trips",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Hotels_HotelId",
                table: "Trips",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Hotels_HotelId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_HotelId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FoodMeals",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IdentityImage",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsInner",
                table: "Cities");
        }
    }
}
