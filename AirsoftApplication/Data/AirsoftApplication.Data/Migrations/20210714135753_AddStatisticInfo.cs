namespace AirsoftApplication.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddStatisticInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_AspNetUsers_UserId",
                table: "Statistic");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Events_EventId",
                table: "Statistic");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticInfo_Guns_GunId",
                table: "StatisticInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticInfo_Statistic_StatisticId",
                table: "StatisticInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatisticInfo",
                table: "StatisticInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistic",
                table: "Statistic");

            migrationBuilder.RenameTable(
                name: "StatisticInfo",
                newName: "StatisticInfos");

            migrationBuilder.RenameTable(
                name: "Statistic",
                newName: "Statistics");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfo_StatisticId",
                table: "StatisticInfos",
                newName: "IX_StatisticInfos_StatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfo_IsDeleted",
                table: "StatisticInfos",
                newName: "IX_StatisticInfos_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfo_GunId",
                table: "StatisticInfos",
                newName: "IX_StatisticInfos_GunId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistic_UserId",
                table: "Statistics",
                newName: "IX_Statistics_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistic_IsDeleted",
                table: "Statistics",
                newName: "IX_Statistics_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Statistic_EventId",
                table: "Statistics",
                newName: "IX_Statistics_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatisticInfos",
                table: "StatisticInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticInfos_Guns_GunId",
                table: "StatisticInfos",
                column: "GunId",
                principalTable: "Guns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticInfos_Statistics_StatisticId",
                table: "StatisticInfos",
                column: "StatisticId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Events_EventId",
                table: "Statistics",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticInfos_Guns_GunId",
                table: "StatisticInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticInfos_Statistics_StatisticId",
                table: "StatisticInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Events_EventId",
                table: "Statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatisticInfos",
                table: "StatisticInfos");

            migrationBuilder.RenameTable(
                name: "Statistics",
                newName: "Statistic");

            migrationBuilder.RenameTable(
                name: "StatisticInfos",
                newName: "StatisticInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_UserId",
                table: "Statistic",
                newName: "IX_Statistic_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_IsDeleted",
                table: "Statistic",
                newName: "IX_Statistic_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_EventId",
                table: "Statistic",
                newName: "IX_Statistic_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfos_StatisticId",
                table: "StatisticInfo",
                newName: "IX_StatisticInfo_StatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfos_IsDeleted",
                table: "StatisticInfo",
                newName: "IX_StatisticInfo_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_StatisticInfos_GunId",
                table: "StatisticInfo",
                newName: "IX_StatisticInfo_GunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistic",
                table: "Statistic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatisticInfo",
                table: "StatisticInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_AspNetUsers_UserId",
                table: "Statistic",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Events_EventId",
                table: "Statistic",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticInfo_Guns_GunId",
                table: "StatisticInfo",
                column: "GunId",
                principalTable: "Guns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticInfo_Statistic_StatisticId",
                table: "StatisticInfo",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
