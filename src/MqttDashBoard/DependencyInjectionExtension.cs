using Microsoft.EntityFrameworkCore;
using MqttDashBoard.Data;
using MqttDashBoard.Services;
using MqttDashBoard.Services.Interfaces;
using MQTTnet;
using MQTTnet.Client;

namespace MqttDashBoard;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton<IMqttService, MqttService>();
        services.AddSingleton<IMqttClient>(opt =>
        {
            var factory = new MqttFactory();
            return factory.CreateMqttClient();
        });
        return services;
    }
}