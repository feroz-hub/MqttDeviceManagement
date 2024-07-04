using Microsoft.AspNetCore.Mvc;
using MqttDashBoard.Infrastructure;

namespace MqttDashBoard.Component;

public class RightSectionViewComponent(IMqttClientRepository mqttClientRepository):ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var clients=await mqttClientRepository.GetAllClientsAsync();
        return View(clients);
    }
}