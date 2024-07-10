namespace DyeStats.Classes;

public class Game {
    public ObjectId? Id { get; set; }
    public string? Name { get; set; }
    public ObjectId? Location { get; set; }
    public DateTime? Date { get; set; } = DateTime.Today;
    public List<Team> Teams { get; set; } = new List<Team>();
}