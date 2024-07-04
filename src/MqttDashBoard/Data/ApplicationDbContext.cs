using Microsoft.EntityFrameworkCore;
using MqttDashBoard.Models;

namespace MqttDashBoard.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
{
    public DbSet<MqttClientModel> MqttClients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MqttClientModel>().HasData(
            new MqttClientModel
            {
                ClientId = Guid.NewGuid(),
                DeviceName = "DeviceAlpha",
                Created = new DateTime(2023, 5, 12, 14, 30, 0),
                SubscribedTopics = ["Test", "LogData"],
                LastAccessed = new DateTime(2024, 6, 24, 9, 45, 0),
                Status = true,
                KeepAlive = 60,
                IpAddress = "192.168.1.1"
            },
            new MqttClientModel
            {
                ClientId = Guid.NewGuid(),
                DeviceName = "DeviceBeta",
                Created = new DateTime(2023, 6, 11, 11, 20, 0),
                SubscribedTopics = ["Test", "Patch","LogData"],
                LastAccessed = new DateTime(2024, 6, 23, 10, 15, 0),
                Status = false,
                KeepAlive = 50,
                IpAddress = "192.168.4.2"
            },
            new MqttClientModel
            {
                ClientId = Guid.NewGuid(),
                DeviceName = "DeviceGamma",
                Created = new DateTime(2023, 7, 21, 9, 45, 0),
                SubscribedTopics = ["Test", "DeviceGamma"],
                LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
                Status = true,
                KeepAlive = 50,
                IpAddress = "192.168.r.3"
            },
        new MqttClientModel
            {
                ClientId = Guid.NewGuid(),
                DeviceName = "NetClient",
                Created = new DateTime(2023, 7, 21, 9, 45, 0),
                SubscribedTopics = ["Test", "NetClient","Card"],
                LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
                Status = true,
                KeepAlive = 60,
                IpAddress = "192.168.1.3"
            },
        new MqttClientModel
        {
            ClientId = Guid.NewGuid(),
            DeviceName = "DeviceZeta",
            Created = new DateTime(2023, 7, 21, 9, 45, 0),
            SubscribedTopics = ["Test", "LogRequest"],
            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
            Status = true,
            KeepAlive = 70,
            IpAddress = "192.167.1.3"
        },
        new MqttClientModel
        {
            ClientId = Guid.NewGuid(),
            DeviceName = "DeviceEta",
            Created = new DateTime(2023, 7, 21, 9, 45, 0),
            SubscribedTopics = ["SealHash", "UnSeal"],
            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
            Status = true,
            KeepAlive = 60,
            IpAddress = "192.168.1.3"
        },
        new MqttClientModel
        {
            ClientId = Guid.NewGuid(),
            DeviceName = "DeviceTheta",
            Created = new DateTime(2023, 7, 21, 9, 45, 0),
            SubscribedTopics = ["Datapack", "topic6"],
            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
            Status = true,
            KeepAlive = 60,
            IpAddress = "192.168.1.3"
        },
        new MqttClientModel
        {
            ClientId = Guid.NewGuid(),
            DeviceName = "DeviceIota",
            Created = new DateTime(2023, 7, 21, 9, 45, 0),
            SubscribedTopics = ["topic5", "topic6"],
            LastAccessed = new DateTime(2024, 6, 22, 16, 30, 0),
            Status = true,
            KeepAlive = 60,
            IpAddress = "192.167.1.3"
        }
            // Add more dummy clients as needed
        );
    }
}