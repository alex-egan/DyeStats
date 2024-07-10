namespace DyeStats.Classes;

public class Player {
    public ObjectId Id { get; set; } = ObjectId.NewObjectId();
    public string Name { get; set; } = "";

    public int GetGameTotal(List<Game> games) {
        return games.Where(g => g.Teams.SelectMany(t => t.Players).Contains(Id)).Count();
    }

    public int GetPlayTotal(List<Play> plays) {
        try {
            return plays.Where(p => p.Tosser == Id).Count();
        }
        catch (Exception) {
            return 0;
        }
    }

    public int GetSinkTotal(List<Play> plays) {
        try {
            return plays.Where(p => p.Tosser == Id && 
                                p.Category == PlayCategory.Sink).Count();
        }
        catch (Exception) {
            return 0;
        }
    }

    public double CalculateHitPercentage(List<Play> plays) {
        try {
            double hits = plays.Where(p => p.Tosser == Id && 
                                    p.Category is PlayCategory.Live or PlayCategory.Sink).Count();
            double total = plays.Count();

            return hits/total * 100;
        }
        catch (Exception) {
            return 0.0;
        }
    }

    public double CalculateCatchPercentage(List<Play> plays) {
        try {
            double catches = plays.Where(p => p.Category == PlayCategory.Live && p.Defender == Id && p.WasCaught).Count();
            double opportunities = plays.Where(p => p.Category == PlayCategory.Live && p.Defender == Id).Count();

            return catches/opportunities * 100;
        }
        catch (Exception) {
            return 0.0;
        }
        
    }

    public double CalculateScorePercentage(List<Play> plays) {
        try {
            double scores = plays
                        .Where(p => p.Tosser == Id && 
                                    p.Category == PlayCategory.Sink || 
                                    (p.Category == PlayCategory.Live && !p.WasCaught))
                        .Count();

            double hits = plays.Where(p => p.Category is PlayCategory.Sink or PlayCategory.Live).Count();

            return scores/hits * 100;
        }
        catch (Exception) {
            return 0.0;
        }
    }

    public double CalculateKickPercentage(List<Play> plays) {
        try {
            double fifas = plays.Where(p => p.Category == PlayCategory.Fifa &&
                                     p.Kicker == Id &&
                                     p.WasCaught).Count();
        
            double opportunities = plays.Where(p => p.Category == PlayCategory.Fifa && 
                                                p.Kicker == Id).Count();
            return fifas/opportunities * 100;
        }
        catch (Exception) {
            return 0.0;
        }
    }

    public double CalculateFifaPercentage(List<Play> plays) {
        try {
            double fifas = plays.Where(p => p.Category == PlayCategory.Fifa &&
                                     p.Catcher == Id &&
                                     p.WasCaught).Count();
        
            double opportunities = plays.Where(p => p.Category == PlayCategory.Fifa && 
                                                p.Catcher == Id).Count();
            return fifas/opportunities * 100;
        }
        catch (Exception) {
            return 0.0;
        }
    }
}