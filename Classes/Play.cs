namespace DyeStats.Classes;

public class Play {
    public ObjectId Id { get; set; } = ObjectId.NewObjectId();
    public DateTime? TimeStamp { get; set; }
    public ObjectId? GameId { get; set; }
    public ObjectId? Tosser { get; set; }
    public PlayCategory? Category { get; set; }
    public ObjectId? Type { get; set; }
    public ObjectId? Defender { get; set; }
    public ObjectId? Kicker { get; set; }
    public ObjectId? Catcher { get; set; }
    public bool WasCaught { get; set; } = false;
    public int Difficulty { get; set; }

    public int CalculatePoints() {
        if (Category == PlayCategory.Live && WasCaught == false) 
        {
            return 1;
        } 
        else if (Category == PlayCategory.Fifa && WasCaught == true) 
        {
            return 1;
        } 
        else if (Category == PlayCategory.Sink) 
        {
            return 3;
        } 
        else 
        {
            return 0;
        }
    }
}