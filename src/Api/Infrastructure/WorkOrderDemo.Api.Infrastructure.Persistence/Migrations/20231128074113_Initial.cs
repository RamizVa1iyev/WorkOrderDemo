using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "WorkOrderImportance",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderImportance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatus",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderImportanceId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderingCompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrder_WorkOrderImportance_OrderImportanceId",
                        column: x => x.OrderImportanceId,
                        principalSchema: "ordering",
                        principalTable: "WorkOrderImportance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrder_WorkOrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalSchema: "ordering",
                        principalTable: "WorkOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalSchema: "ordering",
                        principalTable: "WorkOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitPart",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitPart_Visit_VisitId",
                        column: x => x.VisitId,
                        principalSchema: "ordering",
                        principalTable: "Visit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_WorkOrderId",
                schema: "ordering",
                table: "Visit",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitPart_VisitId",
                schema: "ordering",
                table: "VisitPart",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_OrderImportanceId",
                schema: "ordering",
                table: "WorkOrder",
                column: "OrderImportanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_OrderStatusId",
                schema: "ordering",
                table: "WorkOrder",
                column: "OrderStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitPart",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "Visit",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "WorkOrderImportance",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "WorkOrderStatus",
                schema: "ordering");
        }
    }
}
