using Microsoft.AspNetCore.Mvc;
using MqttDashBoard.Infrastructure;

namespace MqttDashBoard.Controllers;

public class MqttClientController(IMqttClientRepository mqttClientRepository) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var clients=await mqttClientRepository.GetAllClientsAsync();
        return View(clients);
    }
}