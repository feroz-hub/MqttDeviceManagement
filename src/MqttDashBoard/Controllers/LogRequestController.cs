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
            LogRequestDto = new LogRequestDto(),
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

        var view = new LogModel()
        {
            LogRequestDto = viewModel.LogRequestDto,
            LogResponseModel = new LogResponseModel()
            {
                Messages = mqttService.GetMessages().ToList()
            }
        };
        return View("Index",view);
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