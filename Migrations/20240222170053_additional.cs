using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
	/// <inheritdoc />
	public partial class additional : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "listings",
				columns: table => new
				{
					ListingId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_listings", x => x.ListingId);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "listings");
		}
	}
}
