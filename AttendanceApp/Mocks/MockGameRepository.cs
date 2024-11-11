using AttendanceApp.Data;
using AttendanceApp.Repositories;

namespace AttendanceApp.Mocks
{
    public class MockGameRepository : IGameRepository
    {
        public IEnumerable<Game> GetAll() => MockedGame;

        public IEnumerable<Game> GetAllWithPresentAttendees() => MockedGame;

        public void Update(Game game)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        private readonly IEnumerable<Game> MockedGame = new List<Game>() {
                new() { GameId = 123, Title = "Kavok vs Belsele", Date = "10/11/2024 19:00:00", Address = "Overmerestraat 1, 9260 Overmere", Attendees = [] },
                new() { GameId = 456, Title = "Stacco vs Kavok", Date = "21/11/2024 18:00:00", Address = "Wetterenalaan 2, 9260 Wetteren", Attendees = [] },
                new() { GameId = 789, Title = "Willyboys vs Kavok", Date = "11/12/2024 20:00:00", Address = "Willyboysstraat 23, 9234 Willys", Attendees = [] }
        };
    }
}
