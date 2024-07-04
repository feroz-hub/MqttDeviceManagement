using Microsoft.AspNetCore.Mvc;
using MqttDashBoard.Models;
using MqttDashBoard.Services.Interfaces;

namespace MqttDashBoard.Controllers;

public class ProcessRequestController (IMqttService mqttService): Controller
{
    // GET
    public IActionResult Index()
    {
        var viewModel = new ProcessModel()
        {
            ProcessRequestDto = new ProcessRequestDto(),
            ProcessResponseModel = new ProcessResponseModel()
            {
                Messages = mqttService.GetMessages().ToList()
            }
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ProcessModel processModel)
    {
        if (ModelState.IsValid) return RedirectToAction("Index");
        var processRequest = new ProcessRequestModel()
        {
            RequestId = Guid.NewGuid(),
            SourceId = "AdminClient",
            ProcessRequestDto = processModel.ProcessRequestDto,
            RequestDate = DateTime.Now
        };
        await mqttService.MqttPublish(processRequest, processModel.ProcessRequestDto.TargetId);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Subscribe(string topic)
    {
        if (string.IsNullOrEmpty(topic))
        {
            return BadRequest("Topic cannot be null or empty.");
        }

        try
        {
            await mqttService.SubscribeToTopic(topic);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return StatusCode(500, new { success = false, message = $"Error while subscribing to {topic}: {e.Message}" });
        }
    }

    public IActionResult GetMessages()
    {
        var processResponseModel = new ProcessResponseModel()
        {
            Messages = mqttService.GetMessages().ToList()
        };
        return PartialView("_ProcessResponse", processResponseModel);
    }

}