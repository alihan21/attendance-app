using AttendanceApp.Data;

namespace AttendanceApp.ViewModels
{
    public class GameViewModel
    {
        public Player LoggedInPlayer { get; set; }
        public List<Game> Games { get; set; }
    }
}
