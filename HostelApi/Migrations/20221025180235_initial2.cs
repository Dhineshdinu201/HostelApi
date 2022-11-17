using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostelApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfJoining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Advance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WellWisher1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WellWisher1Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WellWisher1Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WellWisher2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WellWisher2Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WellWisher2Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProofUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomRefId = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Room_roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_roomId",
                table: "Users",
                column: "roomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
