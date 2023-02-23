using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TickTick.Data.Migrations
{
    /// <inheritdoc />
    public partial class UseDoubleForSequenceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SequenceNumber",
                table: "PlaylistItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SequenceNumber",
                table: "PlaylistItem",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
