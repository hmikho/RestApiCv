using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Arbetserfarenheter",
                columns: table => new
                {
                    JobbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jobbtitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Företag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Startår = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbetserfarenheter", x => x.JobbID);
                    table.ForeignKey(
                        name: "FK_Arbetserfarenheter_Personer_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Personer",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utbildningar",
                columns: table => new
                {
                    UtbildningID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Examen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utbildningar", x => x.UtbildningID);
                    table.ForeignKey(
                        name: "FK_Utbildningar_Personer_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Personer",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbetserfarenheter_PersonID",
                table: "Arbetserfarenheter",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonID",
                table: "Utbildningar",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbetserfarenheter");

            migrationBuilder.DropTable(
                name: "Utbildningar");

            migrationBuilder.DropTable(
                name: "Personer");
        }
    }
}
