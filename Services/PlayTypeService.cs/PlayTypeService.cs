using DyeStats.Classes;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LogService;

namespace DyeStats.Services.PlayTypeService;

public class PlayTypeService : IPlayTypeService
{
    private readonly ILiteCollection<PlayType> _playTypes;
    private readonly ILogService _logService;

    public PlayTypeService(ILiteDBService liteDBService, ILogService logService) {
        _playTypes = liteDBService.Database.GetCollection<PlayType>("PlayTypes");
        _logService = logService;
    }

    public ServiceResponse<bool?> DeletePlayType(ObjectId id)
    {
        try {
            _playTypes.Delete(id);

            return new ServiceResponse<bool?> {
                Data = true
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<bool?> {
                Success = false,
                Data = null,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<HashSet<PlayType>?> GetAllPlayTypes()
    {
        try {
            HashSet<PlayType> playTypes = _playTypes.FindAll().ToHashSet();

            return new ServiceResponse<HashSet<PlayType>?> {
                Data = playTypes
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<PlayType>?> {
                Success = false,
                Data = null,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<HashSet<PlayType>?> GetAllPlayTypesForLocation(ObjectId locationId)
    {
        try {
            HashSet<PlayType> playTypes = _playTypes.Find(p => p.Locations.Contains(locationId)).ToHashSet();

            return new ServiceResponse<HashSet<PlayType>?> {
                Data = playTypes
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<PlayType>?> {
                Success = false,
                Data = null,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<PlayType?> GetPlayTypeById(ObjectId id)
    {
        try {
            PlayType playType = _playTypes.FindById(id);

            return new ServiceResponse<PlayType?> {
                Data = playType
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<PlayType?> {
                Success = false,
                Data = null,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<PlayType?> UpsertPlayType(PlayType playType)
    {
        try {
            if (playType.Id == null) {
                _playTypes.Insert(playType);
            } else {
                _playTypes.Update(playType);
            }

            return new ServiceResponse<PlayType?> {
                Data = playType
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<PlayType?> {
                Success = false,
                Data = null,
                Message = e.Message
            };
        }
    }
}