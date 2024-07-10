using DyeStats.Classes;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LogService;

namespace DyeStats.Services.PlayService;

public class PlayService : IPlayService
{
    private readonly ILiteCollection<Play> _plays;
    private readonly ILogService _logService;

    public PlayService(ILiteDBService dbService, ILogService logService) {
        _plays = dbService.Database.GetCollection<Play>("Plays");
        _logService = logService;
    }

    public ServiceResponse<bool?> DeletePlay(ObjectId id)
    {
        try {
            _plays.Delete(id);
            return new ServiceResponse<bool?> {
                Data = true
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<bool?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<HashSet<Play>?> GetAllPlays()
    {
        try {
            HashSet<Play> plays = _plays.FindAll().ToHashSet();
            return new ServiceResponse<HashSet<Play>?> {
                Data = plays
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Play>?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<HashSet<Play>?> GetAllPlaysForGame(ObjectId gameId)
    {
        try {
            HashSet<Play> plays = _plays
                                    .Find(play => play.GameId == gameId)
                                    .ToHashSet();
            return new ServiceResponse<HashSet<Play>?> {
                Data = plays
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Play>?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<HashSet<Play>?> GetAllPlaysForPlayer(ObjectId playerId)
    {
        try {
            HashSet<Play> plays = _plays
                                    .Find(play => play.Tosser == playerId ||
                                                  play.Catcher == playerId ||
                                                  play.Defender == playerId ||
                                                  play.Kicker == playerId)
                                    .ToHashSet();
            return new ServiceResponse<HashSet<Play>?> {
                Data = plays
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Play>?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<Play?> GetPlayById(ObjectId id)
    {
        try {
            Play play = _plays.FindById(id);
            return new ServiceResponse<Play?> {
                Data = play
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<Play?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }

    public ServiceResponse<Play?> UpsertPlay(Play play)
    {
        try {
            Play p = _plays.FindById(play.Id);
            if (p != null) {
                _plays.Update(play);
            } else {
                _plays.Insert(play);
            }
            return new ServiceResponse<Play?> {
                Data = play
            };
        } catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<Play?> {
                Data = null,
                Success = false,
                Message = e.Message
            };
        }
    }
}