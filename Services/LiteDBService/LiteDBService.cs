namespace DyeStats.Services.LiteDBService;

public class LiteDBService : ILiteDBService {
    public LiteDatabase Database {get; set;}

    public LiteDBService() {
        Database = new LiteDatabase(new ConnectionString {
            Connection = ConnectionType.Shared,
            Filename = "./LiteDB/DyeStats.db"
        });
    }
}