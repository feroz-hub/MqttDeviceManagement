namespace MqttDashBoard.Models;

public class ProcessModel
{
    public ProcessRequestDto ProcessRequestDto { get; set; }
    public ProcessResponseModel ProcessResponseModel { get; set; }
}
public class ProcessRequestModel
{
    public Guid RequestId { get; set; }
    public string SourceId { get; set; }
    public DateTime RequestDate { get; set; }
    public ProcessRequestDto ProcessRequestDto { get; set; } = new();
}

public class ProcessResponseModel
{
    public List<string> Messages { get; set; } = [];
}

public class ProcessRequestDto
{
    public string TargetId { get; set; }
    public ActionType ActionType { get; set; }
    public bool IsAckRequired { get; set; }
    public ResponseType ResponseType { get; set; }
    public string ProcessName { get; set; }
}