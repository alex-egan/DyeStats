namespace DyeStats.Classes;

public class Log {
    public string? Level { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? UserId { get; set; } = "afegan";
    public DateTime DateTimeStamp { get; set; } = DateTime.Now;
}