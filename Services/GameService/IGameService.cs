using DyeStats.Classes;

namespace DyeStats.Services.GameService;

public interface IGameService {
    ServiceResponse<HashSet<Game>?> GetAllGames();
    ServiceResponse<Game?> GetGameById(ObjectId id);
    ServiceResponse<Game?> UpsertGame(Game game);
    ServiceResponse<bool?> DeleteGame(ObjectId id);
}