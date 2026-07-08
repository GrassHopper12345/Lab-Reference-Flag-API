using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LabReferenceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biomarkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Panel = table.Column<string>(type: "text", nullable: false),
                    ClinicalContext = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biomarkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BiomarkerId = table.Column<int>(type: "integer", nullable: false),
                    SexFilter = table.Column<string>(type: "text", nullable: true),
                    MinAge = table.Column<int>(type: "integer", nullable: true),
                    MaxAge = table.Column<int>(type: "integer", nullable: true),
                    LowNormal = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    HighNormal = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    CriticalLow = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    CriticalHigh = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    SiConversionFactor = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    SiUnit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceRanges_Biomarkers_BiomarkerId",
                        column: x => x.BiomarkerId,
                        principalTable: "Biomarkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biomarkers_Name",
                table: "Biomarkers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceRanges_BiomarkerId_SexFilter_MinAge_MaxAge",
                table: "ReferenceRanges",
                columns: new[] { "BiomarkerId", "SexFilter", "MinAge", "MaxAge" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferenceRanges");

            migrationBuilder.DropTable(
                name: "Biomarkers");
        }
    }
}
