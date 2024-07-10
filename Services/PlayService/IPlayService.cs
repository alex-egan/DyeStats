using DyeStats.Classes;

namespace DyeStats.Services.PlayService;

public interface IPlayService {
    ServiceResponse<HashSet<Play>?> GetAllPlays();
    ServiceResponse<Play?> GetPlayById(ObjectId id);
    ServiceResponse<HashSet<Play>?> GetAllPlaysForGame(ObjectId gameId);
    ServiceResponse<HashSet<Play>?> GetAllPlaysForPlayer(ObjectId playerId);
    ServiceResponse<Play?> UpsertPlay(Play play);
    ServiceResponse<bool?> DeletePlay(ObjectId id);
}