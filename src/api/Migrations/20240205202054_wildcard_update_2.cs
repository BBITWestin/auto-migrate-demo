using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Api.Migrations
{
    /// <inheritdoc />
    public partial class wildcard_update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WildCard2",
                table: "Lists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WildCard2",
                table: "Lists");
        }
    }
}
