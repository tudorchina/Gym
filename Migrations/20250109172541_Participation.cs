using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Migrations
{
    /// <inheritdoc />
    public partial class Participation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Trainer_TrainerID",
                table: "GymClasses");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerID",
                table: "GymClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    GymClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participations_GymClasses_GymClassID",
                        column: x => x.GymClassID,
                        principalTable: "GymClasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_GymClassID",
                table: "Participations",
                column: "GymClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_MemberID",
                table: "Participations",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Trainer_TrainerID",
                table: "GymClasses",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Trainer_TrainerID",
                table: "GymClasses");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerID",
                table: "GymClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Trainer_TrainerID",
                table: "GymClasses",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
