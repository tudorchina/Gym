using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPremiumToGymClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_GymClasses_GymClassID",
                table: "Participations");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Member_MemberID",
                table: "Participations");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Participations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GymClassID",
                table: "Participations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "GymClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_GymClasses_GymClassID",
                table: "Participations",
                column: "GymClassID",
                principalTable: "GymClasses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Member_MemberID",
                table: "Participations",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_GymClasses_GymClassID",
                table: "Participations");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Member_MemberID",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "GymClasses");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Participations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GymClassID",
                table: "Participations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_GymClasses_GymClassID",
                table: "Participations",
                column: "GymClassID",
                principalTable: "GymClasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Member_MemberID",
                table: "Participations",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
