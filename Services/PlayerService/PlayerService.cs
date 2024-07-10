using DyeStats.Classes;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LogService;

namespace DyeStats.Services.PlayerService;

public class PlayerService : IPlayerService
{
    private readonly ILiteCollection<Player> _players;
    private readonly ILogService _logService;

    public PlayerService(ILiteDBService dbService, ILogService logService) {
        _players = dbService.Database.GetCollection<Player>("Players");
        _logService = logService;
    }

    public ServiceResponse<bool?> DeletePlayer(ObjectId id)
    {
        try {
            _players.Delete(id);
            return new ServiceResponse<bool?> {
                Data = true
            };
        } catch (Exception e) 
        {
            _logService.LogError(e);
            return new ServiceResponse<bool?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<HashSet<Player>?> GetAllPlayers()
    {
        try {
            HashSet<Player> players = _players.FindAll().ToHashSet();
            return new ServiceResponse<HashSet<Player>?> {
                Data = players
            };
        } catch (Exception e) 
        {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Player>?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<Player?> GetPlayerById(ObjectId id)
    {
        try {
            Player player = _players.FindById(id);
            return new ServiceResponse<Player?> {
                Data = player
            };
        } catch (Exception e) 
        {
            _logService.LogError(e);
            return new ServiceResponse<Player?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }

    public ServiceResponse<HashSet<Player>?> UpsertPlayers(HashSet<Player> players)
    {
        try {
            foreach (Player player in players) {
                Player p = _players.FindById(player.Id);
                if (p != null) {
                    _players.Update(player);
                } else {
                    _players.Insert(player);
                }
            }

            return new ServiceResponse<HashSet<Player>?> {
                Data = players
            };
        } catch (Exception e) 
        {
            _logService.LogError(e);
            return new ServiceResponse<HashSet<Player>?> {
                Success = false,
                Message = e.Message,
                Data = null
            };
        }
    }
}