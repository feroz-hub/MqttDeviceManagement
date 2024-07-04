using MqttDashBoard.Models;

namespace MqttDashBoard.Infrastructure;

public class MqttClientRepository:IMqttClientRepository
{
    public async Task<List<string>> GetActiveClientIdsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<MqttClientModel>> GetAllClientsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> GetAllClient()
    {
        throw new NotImplementedException();
    }

    public async Task RegisterClientAsync(MqttClientModel mqttClientRegistration)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateClientAsync(MqttClientModel clientRegistration)
    {
        throw new NotImplementedException();
    }
}