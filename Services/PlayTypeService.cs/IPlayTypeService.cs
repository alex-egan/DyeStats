using DyeStats.Classes;

namespace DyeStats.Services.PlayTypeService;

public interface IPlayTypeService {
    ServiceResponse<HashSet<PlayType>?> GetAllPlayTypes();
    ServiceResponse<PlayType?> GetPlayTypeById(ObjectId id);
    ServiceResponse<HashSet<PlayType>?> GetAllPlayTypesForLocation(ObjectId locationId);
    ServiceResponse<PlayType?> UpsertPlayType(PlayType playType);
    ServiceResponse<bool?> DeletePlayType(ObjectId id);
}