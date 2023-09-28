using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Project_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class IdentyUserAndRolesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_userId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Orders",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Orders",
                newName: "dateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_userId",
                table: "Orders",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
