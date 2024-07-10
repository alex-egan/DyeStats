namespace DyeStats.Classes;

public class Location {
    public ObjectId Id { get; set; } = ObjectId.NewObjectId();
    public string? Name { get; set; } = "";
    public string? Description { get; set; } = "";
    public List<PlayType> HouseRules { get; set; } = new List<PlayType>();
}