using AttendanceApp.Data;
using AttendanceApp.Repositories;
using System.Linq;

namespace AttendanceApp.Mocks
{
    public class MockPlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> GetAllPlayers()
        {
            return MockedPlayers;
        }

        public Player GetPlayerById(int playerId)
        {
            var player = MockedPlayers.FirstOrDefault(player => player.PlayerId == playerId);

            if (player == null)
            {
                player = new Player
                {
                    PlayerId = -1,
                    Name = "Default"
                };
            }

            return player;
        }




        private readonly IEnumerable<Player> MockedPlayers = new List<Player>() {
            new() { PlayerId = 123, Name = "Alihan Fevziev", PlayerImage = "none" },
            new() { PlayerId = 456, Name = "Staf Lautsnay", PlayerImage = "none" },
            new() { PlayerId = 789, Name = "Yves De Backer", PlayerImage = "none" }
        };
    }
}
