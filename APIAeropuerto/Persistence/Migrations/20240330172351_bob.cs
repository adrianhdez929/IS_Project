using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAeropuerto.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairServices_Services_IdService1",
                table: "RepairServices");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairServices_Services_IdService1",
                table: "RepairServices",
                column: "IdService1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairServices_Services_IdService1",
                table: "RepairServices");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairServices_Services_IdService1",
                table: "RepairServices",
                column: "IdService1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
