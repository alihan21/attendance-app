using AttendanceApp.Data;
using AttendanceApp.Repositories;

namespace AttendanceApp.Mocks
{
    public class MockPlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> GetAllPlayers()
        {
            return
            [
               new Player { PlayerId = "123", Name = "Alihan Fevziev", PlayerImage = "none" },
               new Player { PlayerId = "456", Name = "Staf Lautsnay", PlayerImage = "none" },
               new Player { PlayerId = "789", Name = "Yves De Backer", PlayerImage = "none" }
            ];
        }
    }
}
