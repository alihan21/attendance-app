using AttendanceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApp.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();

        IEnumerable<Game> GetAllWithPresentAttendees();

        void Update(Game game);

        void SaveChanges();
    }
}
