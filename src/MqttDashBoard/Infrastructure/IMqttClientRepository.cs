using MqttDashBoard.Models;

namespace MqttDashBoard.Infrastructure;

public interface IMqttClientRepository
{
    Task<List<string>> GetActiveClientIdsAsync();
    Task<List<MqttClientModel>> GetAllClientsAsync();
    Task<List<string>> GetAllClient();
    Task RegisterClientAsync(MqttClientModel mqttClientRegistration);
    Task UpdateClientAsync(MqttClientModel clientRegistration);
}