namespace DyeStats.Classes;

public class PlayType {
    public ObjectId? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ObjectId> Locations { get; set; } = new List<ObjectId>();
    public bool CatchRequired { get; set; } = false;
    public int[] Points { get; set; } = new int[2];
    public PlayCategory Category { get; set; } = PlayCategory.Dead;
}