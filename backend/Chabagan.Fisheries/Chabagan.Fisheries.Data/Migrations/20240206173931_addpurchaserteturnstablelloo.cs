using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpurchaserteturnstablelloo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_PurchaseReturns_DbPurchaseReturnId",
                table: "PurchaseReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseReturnId",
                table: "PurchaseReturnItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnItems_DbPurchaseReturnId",
                table: "PurchaseReturnItems");

            migrationBuilder.DropColumn(
                name: "DbPurchaseReturnId",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseReturnId",
                table: "PurchaseReturnItems",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_PurchaseReturnId",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_PurchaseId");

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
                name: "FK_PurchaseReturnItems_PurchaseReturns_PurchaseId",
                table: "PurchaseReturnItems",
                column: "PurchaseId",
                principalTable: "PurchaseReturns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_PurchaseReturns_PurchaseId",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "PurchaseReturnItems",
                newName: "PurchaseReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_PurchaseId",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_PurchaseReturnId");

            migrationBuilder.AddColumn<long>(
                name: "DbPurchaseReturnId",
                table: "PurchaseReturnItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "aYCxPtaSdSdn8UPLggPgEMYS+1t6zI1ZHNFxDSEnPYs=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "IrH3r7bLIaZyoDKhTVvmBQ3zRthn2qzWfkWUjw6WXX8=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "aYCxPtaSdSdn8UPLggPgEMYS+1t6zI1ZHNFxDSEnPYs=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnItems_DbPurchaseReturnId",
                table: "PurchaseReturnItems",
                column: "DbPurchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_PurchaseReturns_DbPurchaseReturnId",
                table: "PurchaseReturnItems",
                column: "DbPurchaseReturnId",
                principalTable: "PurchaseReturns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseReturnId",
                table: "PurchaseReturnItems",
                column: "PurchaseReturnId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
