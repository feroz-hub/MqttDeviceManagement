namespace MqttDashBoard.Services.Interfaces;

public interface IMqttService
{
    Task SubscribeToTopic(string topic);
    Task MqttPublish<T>(T message, string topic) where T : class;
    IEnumerable<string> GetMessages();
    event Func<string, string, Task>? MessageReceived;
}