using DyeStats.Classes;
using DyeStats.Services.LiteDBService;

namespace DyeStats.Services.LogService;

public class LogService : ILogService
{
    private readonly ILiteCollection<Log> _logs;

    public LogService(ILiteDBService dbService) {
        _logs = dbService.Database.GetCollection<Log>("Logs");
    }

    public void LogError(Exception e)
    {
        try {
            Log log = new Log {
                Message = e.Message,
                StackTrace = e.StackTrace,
                Level = "Error"
            };

            _logs.Insert(log);
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
    }

    public void LogMessage(string message)
    {
        try {
            Log log = new Log {
                Message = message,
                Level = "Message"
            };
            
            _logs.Insert(log);
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
    }

    public void LogWarning(string warning)
    {
        try {
            Log log = new Log {
                Message = warning,
                Level = "Warning"
            };
            
            _logs.Insert(log);
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
    }
}