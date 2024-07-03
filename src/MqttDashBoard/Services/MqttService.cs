using System.Collections.Concurrent;
using System.Text;
using MqttDashBoard.Services.Interfaces;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Newtonsoft.Json;

namespace MqttDashBoard.Services;

public class MqttService:IMqttService
{
    private readonly IMqttClient _mqttClient;
    private readonly ConcurrentBag<string> _messages;
    public event Func<string, string, Task>? MessageReceived;
    private readonly MqttClientOptions _options;
    public MqttService()
    {
        var factory = new MqttFactory();
        
        _mqttClient = factory.CreateMqttClient();
        _messages = new ConcurrentBag<string>();
        
        _options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .WithClientId("Client2_Subscriber")
            .WithKeepAlivePeriod(TimeSpan.FromMinutes(60))
            .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
            .Build();
        _mqttClient.ApplicationMessageReceivedAsync += async e =>
        {
            var message = $"Received Message on Topic: '{e.ApplicationMessage.Topic}' with Content '{e.ApplicationMessage.ConvertPayloadToString()}'";
            _messages.Add(message);
            // if (MessageReceived != null)
            //     await MessageReceived(message, e.ApplicationMessage.Topic);
            await Task.CompletedTask;
        };

        _mqttClient.ConnectAsync(_options, CancellationToken.None).Wait();
        _mqttClient.DisconnectedAsync += async e =>
        {
            await Task.Delay(TimeSpan.FromSeconds(5)); // Wait before reconnecting
            try
            {
                await _mqttClient.ConnectAsync(_options, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reconnecting failed: " + ex.Message);
            }
        };
    }
    
    private bool IsConnected => _mqttClient.IsConnected;
    private async Task ConnectClient()
    {
        try
        {
            await _mqttClient.ConnectAsync(_options, CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Connection failed: " + ex.Message);
        }
    }
    public async Task SubscribeToTopic(string topic)
    {
        if (!IsConnected)
        {
            await ConnectClient();
        }
        if (IsConnected)
        {
            await _mqttClient.SubscribeAsync(topic);
        }
        else
        {
            throw new InvalidOperationException("MQTT client is not connected.");
        }
    }

    public async Task MqttPublish<T>(T message,string topic) where T : class
    {
        var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        if (!IsConnected)
        {
            await ConnectClient(); // Connect if not connected
        }
        if (IsConnected)
        {
            await _mqttClient.PublishAsync(new MqttApplicationMessage()
            {
                Topic = topic,
                Payload = data,
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
                Retain = true
            });
        }
    }
    public IEnumerable<string> GetMessages()
    {
        return _messages;
    }
}