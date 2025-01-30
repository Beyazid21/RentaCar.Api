using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRentCarTableToDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "RentCars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationId",
                table: "RentCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
