using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpurchaserteturnstablelloodd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Products_ProductID",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductID",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "PurchaseReturnItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_ProductID",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "PurchaseItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_ProductID",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_ProductId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "oRxKwaqHJEuwSKyiFTym74vmQ7l/aMzAn7i9JSKFOp0=", "Q7/OkVoIfz9mjeYkrnDdnw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "3JNTXCClrJ/G4L5KPv0OchbQG0x6DExhFDQpnb2gYhc=", "Q7/OkVoIfz9mjeYkrnDdnw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "oRxKwaqHJEuwSKyiFTym74vmQ7l/aMzAn7i9JSKFOp0=", "Q7/OkVoIfz9mjeYkrnDdnw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductId",
                table: "PurchaseReturnItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductId",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PurchaseReturnItems",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_ProductId",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_ProductID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PurchaseItems",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_ProductID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "cYlUHDey307il6pdviq5WNakFXrleJjdIlSaFHmcA7c=", "z2KDEWQRLvYtMTvPCd0Cog==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "zkGY+6+zi4CBqkhFwIW2ktg44EOHnA5W0GmWmU1fM0E=", "z2KDEWQRLvYtMTvPCd0Cog==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "cYlUHDey307il6pdviq5WNakFXrleJjdIlSaFHmcA7c=", "z2KDEWQRLvYtMTvPCd0Cog==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Products_ProductID",
                table: "PurchaseItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductID",
                table: "PurchaseReturnItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
