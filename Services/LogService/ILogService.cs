namespace DyeStats.Services.LogService;

public interface ILogService {
    void LogError(Exception e);
    void LogMessage(string message);
    void LogWarning(string warning);
}