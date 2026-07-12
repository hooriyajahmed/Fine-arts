using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class evaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaintingId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    MarksCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositiveRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NegativeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprovementRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_evaluations_paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "paintings",
                        principalColumn: "PaintingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_evaluations_staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_PaintingId",
                table: "evaluations",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_StaffId",
                table: "evaluations",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evaluations");
        }
    }
}
