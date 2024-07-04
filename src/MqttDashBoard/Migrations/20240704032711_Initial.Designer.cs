﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MqttDashBoard.Data;

#nullable disable

namespace MqttDashBoard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240704032711_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("MqttDashBoard.Models.MqttClientModel", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KeepAlive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubscribedTopics")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientId");

                    b.ToTable("MqttClients");

                    b.HasData(
                        new
                        {
                            ClientId = new Guid("1157d005-f83b-4202-9380-ec595e6329a4"),
                            Created = new DateTime(2023, 5, 12, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceAlpha",
                            IpAddress = "192.168.1.1",
                            KeepAlive = 60,
                            LastAccessed = new DateTime(2024, 6, 24, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"Test\",\"LogData\"]"
                        },
                        new
                        {
                            ClientId = new Guid("84a627a8-2d6a-4823-80c2-680a7d70b1c5"),
                            Created = new DateTime(2023, 6, 11, 11, 20, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceBeta",
                            IpAddress = "192.168.4.2",
                            KeepAlive = 50,
                            LastAccessed = new DateTime(2024, 6, 23, 10, 15, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            SubscribedTopics = "[\"Test\",\"Patch\",\"LogData\"]"
                        },
                        new
                        {
                            ClientId = new Guid("9a5e0fc9-c169-420b-a975-308fff9a609f"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceGamma",
                            IpAddress = "192.168.r.3",
                            KeepAlive = 50,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"Test\",\"DeviceGamma\"]"
                        },
                        new
                        {
                            ClientId = new Guid("f8d0d2be-2187-41e1-9451-b3beadfdea9a"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "NetClient",
                            IpAddress = "192.168.1.3",
                            KeepAlive = 60,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"Test\",\"NetClient\",\"Card\"]"
                        },
                        new
                        {
                            ClientId = new Guid("37078229-5e20-4a78-af0d-df1a692f7f02"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceZeta",
                            IpAddress = "192.167.1.3",
                            KeepAlive = 70,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"Test\",\"LogRequest\"]"
                        },
                        new
                        {
                            ClientId = new Guid("13f36cc3-8573-4a52-a1e3-269739ab32dd"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceEta",
                            IpAddress = "192.168.1.3",
                            KeepAlive = 60,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"SealHash\",\"UnSeal\"]"
                        },
                        new
                        {
                            ClientId = new Guid("7c32862a-615f-4454-b580-335482b8cc34"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceTheta",
                            IpAddress = "192.168.1.3",
                            KeepAlive = 60,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"Datapack\",\"topic6\"]"
                        },
                        new
                        {
                            ClientId = new Guid("740c32eb-035e-4190-8237-2b471baa93e9"),
                            Created = new DateTime(2023, 7, 21, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            DeviceName = "DeviceIota",
                            IpAddress = "192.167.1.3",
                            KeepAlive = 60,
                            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            SubscribedTopics = "[\"topic5\",\"topic6\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
