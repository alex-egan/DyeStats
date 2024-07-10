using DyeStats.Classes;

namespace DyeStats.Services.LocationService;

public interface ILocationService {
    ServiceResponse<List<Location>?> GetAllLocations();
    ServiceResponse<Location?> GetLocationById(ObjectId id);
    ServiceResponse<Location?> UpsertLocation(Location location);
    ServiceResponse<bool?> DeleteLocation(ObjectId id);
}