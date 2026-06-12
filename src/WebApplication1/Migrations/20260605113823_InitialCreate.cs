using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedisApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorInsurerPaidClaimStatus = table.Column<int>(type: "int", nullable: true),
                    GarageType = table.Column<int>(type: "int", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfLoss = table.Column<int>(type: "int", nullable: true),
                    CauseOfLoss = table.Column<int>(type: "int", nullable: true),
                    LossReporter = table.Column<int>(type: "int", nullable: true),
                    DeclarationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreferredChannel = table.Column<int>(type: "int", nullable: true),
                    ExcessAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepairingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PayeeType = table.Column<int>(type: "int", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
