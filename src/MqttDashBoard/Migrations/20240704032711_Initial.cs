using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MqttDashBoard.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MqttClients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SubscribedTopics = table.Column<string>(type: "TEXT", nullable: false),
                    LastAccessed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    KeepAlive = table.Column<int>(type: "INTEGER", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MqttClients", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "MqttClients",
                columns: new[] { "ClientId", "Created", "DeviceName", "IpAddress", "KeepAlive", "LastAccessed", "Status", "SubscribedTopics" },
                values: new object[,]
                {
                    { new Guid("1157d005-f83b-4202-9380-ec595e6329a4"), new DateTime(2023, 5, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), "DeviceAlpha", "192.168.1.1", 60, new DateTime(2024, 6, 24, 9, 45, 0, 0, DateTimeKind.Unspecified), true, "[\"Test\",\"LogData\"]" },
                    { new Guid("13f36cc3-8573-4a52-a1e3-269739ab32dd"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "DeviceEta", "192.168.1.3", 60, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"SealHash\",\"UnSeal\"]" },
                    { new Guid("37078229-5e20-4a78-af0d-df1a692f7f02"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "DeviceZeta", "192.167.1.3", 70, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"Test\",\"LogRequest\"]" },
                    { new Guid("740c32eb-035e-4190-8237-2b471baa93e9"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "DeviceIota", "192.167.1.3", 60, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"topic5\",\"topic6\"]" },
                    { new Guid("7c32862a-615f-4454-b580-335482b8cc34"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "DeviceTheta", "192.168.1.3", 60, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"Datapack\",\"topic6\"]" },
                    { new Guid("84a627a8-2d6a-4823-80c2-680a7d70b1c5"), new DateTime(2023, 6, 11, 11, 20, 0, 0, DateTimeKind.Unspecified), "DeviceBeta", "192.168.4.2", 50, new DateTime(2024, 6, 23, 10, 15, 0, 0, DateTimeKind.Unspecified), false, "[\"Test\",\"Patch\",\"LogData\"]" },
                    { new Guid("9a5e0fc9-c169-420b-a975-308fff9a609f"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "DeviceGamma", "192.168.r.3", 50, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"Test\",\"DeviceGamma\"]" },
                    { new Guid("f8d0d2be-2187-41e1-9451-b3beadfdea9a"), new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "NetClient", "192.168.1.3", 60, new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified), true, "[\"Test\",\"NetClient\",\"Card\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttClients");
        }
    }
}
