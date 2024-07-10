using DyeStats.Classes;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LogService;

namespace DyeStats.Services.LocationService;

public class LocationService : ILocationService
{
    private readonly ILiteCollection<Location> _locations;
    private readonly ILogService _logService;

    public LocationService(ILiteDBService dbService, ILogService logService) {
        _locations = dbService.Database.GetCollection<Location>("Locations");
        _logService = logService;
    }

    public ServiceResponse<bool?> DeleteLocation(ObjectId id)
    {
        try {
            _locations.Delete(id);

            return new ServiceResponse<bool?> {
                Data = true
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            
            return new ServiceResponse<bool?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<List<Location>?> GetAllLocations()
    {
        try {
            List<Location> locations = _locations.FindAll().ToList();

            return new ServiceResponse<List<Location>?> {
                Data = locations
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<List<Location>?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<Location?> GetLocationById(ObjectId id)
    {
        try {
            Location location = _locations.FindById(id);

            return new ServiceResponse<Location?> {
                Data = location
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<Location?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<Location?> UpsertLocation(Location location)
    {
        try {
            Location? l = _locations.FindById(location.Id);

            if (l != null) {
                _locations.Update(location);
            } else {
                _locations.Insert(location);
            }

            return new ServiceResponse<Location?> {
                Data = location
            };
        } catch (Exception e) 
        {
            _logService.LogError(e);
            return new ServiceResponse<Location?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }
}