namespace DyeStats.Classes;

public class Team {
    public List<ObjectId> Players { get; set; } = new List<ObjectId>();
    public List<string> TestProp { get; set; } = new List<string> {
        "Hi James",
        "What's up."
    };
    public int Score { get; set; } = 0;
}