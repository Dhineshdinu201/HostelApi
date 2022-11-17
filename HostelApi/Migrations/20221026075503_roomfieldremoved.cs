using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostelApi.Migrations
{
    public partial class roomfieldremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_roomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "roomId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roomId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_roomId",
                table: "Users",
                column: "roomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
