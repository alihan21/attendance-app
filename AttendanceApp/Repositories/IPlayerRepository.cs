using AttendanceApp.Data;

namespace AttendanceApp.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int playerId);
    }
}
