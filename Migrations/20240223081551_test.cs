using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_listings",
                table: "listings");

            migrationBuilder.RenameTable(
                name: "listings",
                newName: "Listings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "ListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "listings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_listings",
                table: "listings",
                column: "ListingId");
        }
    }
}
