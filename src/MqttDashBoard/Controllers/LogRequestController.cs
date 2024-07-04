using Microsoft.AspNetCore.Mvc;
using MqttDashBoard.Models;
using MqttDashBoard.Services.Interfaces;

namespace MqttDashBoard.Controllers;

public class LogRequestController(IMqttService mqttService) : Controller
{
    public IActionResult Index()
    {
        //_mqttService.MessageReceived += OnMessageReceived;
        var viewmodel = new LogModel()
        {
            LogResponseModel = new LogResponseModel
            {
                Messages = mqttService.GetMessages().ToList()
                //Messages = messageService.Messages
            }
        };
        return View(viewmodel);
    }
    
    // private Task OnMessageReceived(string message, string topic)
    // {
    //    
    //         _messageService.Messages.Add($"{topic}: {message}");
    //         return Task.CompletedTask;
    // }
    [HttpPost]
    public async Task<IActionResult> Index(LogModel viewModel)
    {
        if (ModelState.IsValid) return RedirectToAction("Index");
        var dto = new LogRequestModel
        {
            RequestId = Guid.NewGuid(),
            SourceId = "AdminClient",
            LogRequestDto = viewModel.LogRequestDto,
            RequestDate = DateTime.Now
        };
        await mqttService.MqttPublish(dto, viewModel.LogRequestDto.TargetId);
        //await mqttService.SubscribeToTopic("");

        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Subscribe(string topic)
    {
        if (string.IsNullOrEmpty(topic)) return RedirectToAction("Index");
        try
        {
            await mqttService.SubscribeToTopic(topic);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = $"Error while subscribing to {topic}: {e.Message}";
        }

        return RedirectToAction("Index");
    }

    public IActionResult GetMessagesPartial()
    {
        // _mqttService.MessageReceived += OnMessageReceived;

      
        var logResponseModel = new LogResponseModel
        {
            Messages = mqttService.GetMessages().ToList()
            //Messages=messageService.Messages
        };
        return PartialView("_LogResponse", logResponseModel);
    }
    public IActionResult Privacy()
    {
        return View();
    }
}