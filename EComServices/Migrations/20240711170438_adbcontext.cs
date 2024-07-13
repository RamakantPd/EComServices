using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComServices.Migrations
{
    /// <inheritdoc />
    public partial class adbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "D_CartItems",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "D_CartItems",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "D_CartItems");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "D_CartItems",
                newName: "Price");
        }
    }
}
