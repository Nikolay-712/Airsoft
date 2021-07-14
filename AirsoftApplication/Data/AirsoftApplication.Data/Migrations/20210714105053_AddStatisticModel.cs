namespace AirsoftApplication.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddStatisticModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistic_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatisticInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatisticId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GunId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GunEnergy = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticInfo_Guns_GunId",
                        column: x => x.GunId,
                        principalTable: "Guns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatisticInfo_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_EventId",
                table: "Statistic",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_IsDeleted",
                table: "Statistic",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_UserId",
                table: "Statistic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticInfo_GunId",
                table: "StatisticInfo",
                column: "GunId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticInfo_IsDeleted",
                table: "StatisticInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticInfo_StatisticId",
                table: "StatisticInfo",
                column: "StatisticId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticInfo");

            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
