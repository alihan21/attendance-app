using AttendanceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApp.Repositories
{
    public class GameRepositoryImpl : IGameRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Game> _games;

        public GameRepositoryImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _games = _appDbContext.Games;
        }

        public void Update(Game game)
        {
            _games.Update(game);
        }

        public IEnumerable<Game> GetAll() => _appDbContext.Games.Include(g => g.Attendees);

        public IEnumerable<Game> GetAllWithPresentAttendees() => _appDbContext.Games.Include(g => g.Attendees).Where(g => g.Attendees.Any(a => a.IsPresent == (short)AttendanceType.Present));

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
