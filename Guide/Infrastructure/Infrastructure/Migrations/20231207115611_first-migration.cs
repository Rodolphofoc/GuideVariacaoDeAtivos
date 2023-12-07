using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "varchar(50)", nullable: true),
                    Symbol = table.Column<string>(type: "varchar(50)", nullable: true),
                    ExchangeName = table.Column<string>(type: "varchar(100)", nullable: true),
                    InstrumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstTradeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegularMarketTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gmtoffset = table.Column<int>(type: "int", nullable: true),
                    Timezone = table.Column<string>(type: "varchar(100)", nullable: true),
                    ExchangeTimezoneName = table.Column<string>(type: "varchar(100)", nullable: true),
                    RegularMarketPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ChartPreviousClose = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PreviousClose = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Scale = table.Column<int>(type: "int", nullable: true),
                    PriceHint = table.Column<int>(type: "int", nullable: true),
                    DataGranularity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTradingPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(10)", nullable: true),
                    Timezone = table.Column<string>(type: "varchar(10)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime", nullable: true),
                    End = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gmtoffset = table.Column<int>(type: "int", nullable: true),
                    MetaId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTradingPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentTradingPeriod_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradingPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timezone = table.Column<string>(type: "varchar(10)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime", nullable: true),
                    End = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gmtoffset = table.Column<int>(type: "int", nullable: true),
                    MetaId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingPeriod_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "varchar(50)", nullable: true),
                    MetaId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidRanges_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote.Close",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote.Close", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote.Close_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote.High",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeStamp = table.Column<int>(type: "int", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote.High", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote.High_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote.Low",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeStamp = table.Column<int>(type: "int", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote.Low", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote.Low_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote.Open",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeStamp = table.Column<int>(type: "int", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote.Open", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote.Open_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote.Volume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeStamp = table.Column<int>(type: "int", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote.Volume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote.Volume_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTradingPeriod_MetaId",
                table: "CurrentTradingPeriod",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_MetaId",
                table: "Quote",
                column: "MetaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quote.Close_QuoteId",
                table: "Quote.Close",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote.High_QuoteId",
                table: "Quote.High",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote.Low_QuoteId",
                table: "Quote.Low",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote.Open_QuoteId",
                table: "Quote.Open",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote.Volume_QuoteId",
                table: "Quote.Volume",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingPeriod_MetaId",
                table: "TradingPeriod",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidRanges_MetaId",
                table: "ValidRanges",
                column: "MetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTradingPeriod");

            migrationBuilder.DropTable(
                name: "Quote.Close");

            migrationBuilder.DropTable(
                name: "Quote.High");

            migrationBuilder.DropTable(
                name: "Quote.Low");

            migrationBuilder.DropTable(
                name: "Quote.Open");

            migrationBuilder.DropTable(
                name: "Quote.Volume");

            migrationBuilder.DropTable(
                name: "TradingPeriod");

            migrationBuilder.DropTable(
                name: "ValidRanges");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Meta");
        }
    }
}
