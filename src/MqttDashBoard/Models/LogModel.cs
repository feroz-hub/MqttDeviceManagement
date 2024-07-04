namespace MqttDashBoard.Models;

public class LogModel
{
    public LogRequestDto LogRequestDto { get; set; }
    public LogResponseModel LogResponseModel { get; set; }
}
public class LogRequestModel
{
    public Guid RequestId { get; init; }=Guid.NewGuid();
    public string SourceId { get; init; } = "Admin";
    public DateTime RequestDate { get; init; }=DateTime.Now;
    public LogRequestDto LogRequestDto { get; init; } = default!;
}
public class LogRequestDto
{
    public string TargetId { get; init; }=default!;
    public List<LogType>  LogTypes { get; init; }= [];
    public List<LogLevel> LogLevels { get; init; } = [];
    public bool IsAckRequired { get; init; } 
    public ActionType ActionType { get; init; }
    public ResponseType ResponseType { get; init; }
    public DateTime FromDate { get; init; } = DateTime.Now;
    public DateTime EndDate { get; init; }=DateTime.Now;
}
public class LogResponseModel
{
    public List<string> Messages { get; set; } = [];
}