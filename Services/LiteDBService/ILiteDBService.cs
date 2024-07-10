namespace DyeStats.Services.LiteDBService;

public interface ILiteDBService {
    LiteDatabase Database {get; set;}
}