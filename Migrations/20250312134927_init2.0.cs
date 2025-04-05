using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Api.Migrations
{
    /// <inheritdoc />
    public partial class init20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbetserfarenheter_Personer_PersonID",
                table: "Arbetserfarenheter");

            migrationBuilder.DropForeignKey(
                name: "FK_Utbildningar_Personer_PersonID",
                table: "Utbildningar");

            migrationBuilder.DropIndex(
                name: "IX_Utbildningar_PersonID",
                table: "Utbildningar");

            migrationBuilder.DropIndex(
                name: "IX_Arbetserfarenheter_PersonID",
                table: "Arbetserfarenheter");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Utbildningar");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Arbetserfarenheter");

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonID_FK",
                table: "Utbildningar",
                column: "PersonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Arbetserfarenheter_PersonID_FK",
                table: "Arbetserfarenheter",
                column: "PersonID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbetserfarenheter_Personer_PersonID_FK",
                table: "Arbetserfarenheter",
                column: "PersonID_FK",
                principalTable: "Personer",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utbildningar_Personer_PersonID_FK",
                table: "Utbildningar",
                column: "PersonID_FK",
                principalTable: "Personer",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbetserfarenheter_Personer_PersonID_FK",
                table: "Arbetserfarenheter");

            migrationBuilder.DropForeignKey(
                name: "FK_Utbildningar_Personer_PersonID_FK",
                table: "Utbildningar");

            migrationBuilder.DropIndex(
                name: "IX_Utbildningar_PersonID_FK",
                table: "Utbildningar");

            migrationBuilder.DropIndex(
                name: "IX_Arbetserfarenheter_PersonID_FK",
                table: "Arbetserfarenheter");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Utbildningar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Arbetserfarenheter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonID",
                table: "Utbildningar",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Arbetserfarenheter_PersonID",
                table: "Arbetserfarenheter",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbetserfarenheter_Personer_PersonID",
                table: "Arbetserfarenheter",
                column: "PersonID",
                principalTable: "Personer",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utbildningar_Personer_PersonID",
                table: "Utbildningar",
                column: "PersonID",
                principalTable: "Personer",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
