using DyeStats.Classes;

namespace DyeStats.Services.PlayerService;

public interface IPlayerService {
    ServiceResponse<HashSet<Player>?> GetAllPlayers();
    ServiceResponse<Player?> GetPlayerById(ObjectId id);
    ServiceResponse<HashSet<Player>?> UpsertPlayers(HashSet<Player> players);
    ServiceResponse<bool?> DeletePlayer(ObjectId id);
}