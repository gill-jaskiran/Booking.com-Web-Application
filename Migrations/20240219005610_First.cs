using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
	/// <inheritdoc />
	public partial class First : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "CarRentals",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
					RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CarRentals", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "FlightBookings",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
					DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FlightBookings", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "HotelBookings",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Hotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
					GuestsPerRoom = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HotelBookings", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "CarRentals");

			migrationBuilder.DropTable(
				name: "FlightBookings");

			migrationBuilder.DropTable(
				name: "HotelBookings");
		}
	}
}
