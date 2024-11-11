using AttendanceApp.Data;

namespace AttendanceApp.Repositories
{
    public class PlayerRepositoryImpl : IPlayerRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Player _defaultPlayer = new Player()
        {
            Name = "Default",
            PlayerImage = "Default"
        };

        public PlayerRepositoryImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Player> GetAllPlayers() => _appDbContext.Players;

        public Player GetPlayerById(int playerId)
        {
            return _appDbContext.Players.Find(playerId) ?? _defaultPlayer;
        }
    }
}
