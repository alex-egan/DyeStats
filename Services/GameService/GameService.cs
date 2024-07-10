using DyeStats.Classes;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LogService;

namespace DyeStats.Services.GameService;

public class GameService : IGameService
{
    private readonly ILiteCollection<Game> _games;
    private readonly ILogService _logService;

    public GameService(ILiteDBService dbService, ILogService logService) {
        _games = dbService.Database.GetCollection<Game>("Games");
        _logService = logService;
    }

    public ServiceResponse<bool?> DeleteGame(ObjectId id)
    {
        try {
            _games.Delete(id);

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

    public ServiceResponse<HashSet<Game>?> GetAllGames()
    {
        try {
            HashSet<Game> games = _games.FindAll().ToHashSet();

            return new ServiceResponse<HashSet<Game>?> {
                Data = games
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Game>?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<Game?> GetGameById(ObjectId id)
    {
        try {
            Game game = _games.FindById(id);

            return new ServiceResponse<Game?> {
                Data = game
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<Game?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<Game?> UpsertGame(Game game)
    {
        try {
            Game g = _games.FindById(game.Id);
            _logService.LogMessage($"Here is the player ID: {game.Teams[0].Players[0].ToString()}");

            if (g != null) {
                _games.Update(game);
            } else {
                _games.Insert(game);
            }

            return new ServiceResponse<Game?> {
                Data = game
            };
        }
        catch (Exception e) {
            _logService.LogError(e);
            return new ServiceResponse<Game?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }
}