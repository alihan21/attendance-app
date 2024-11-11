using AttendanceApp.Data;
using AttendanceApp.Repositories;
using AttendanceApp.Util;
using AttendanceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;

        public GameController(IPlayerRepository playerRepository, IGameRepository gameRepository) {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }

        [Route("player/{id}/game/getall")]
        public IActionResult GetAll(int id)
        {
            Player loggedInPlayer = _playerRepository.GetPlayerById(id);

            List<Game> allGames = _gameRepository.GetAll().ToList();

            return View(new GameViewModel() { Games = allGames, LoggedInPlayer = loggedInPlayer });
        }

        [Route("present/{gameId}/game/{playerId}")]
        [HttpPost]
        public IActionResult SubmitAttendancePresent(int gameId, int playerId)
        {
            return ProcessSubmitAttendance(playerId, gameId, AttendanceType.Present);
        }

        [Route("maybe/{gameId}/game/{playerId}")]
        [HttpPost]
        public IActionResult SubmitAttendanceMaybe(int playerId, int gameId)
        {
            return ProcessSubmitAttendance(playerId, gameId, AttendanceType.Maybe);
        }

        [Route("absent/{gameId}/game/{playerId}")]
        [HttpPost]
        public IActionResult SubmitAttendanceAbsent(int playerId, int gameId)
        {
           return ProcessSubmitAttendance(playerId, gameId, AttendanceType.Absent);
        }

        private ViewResult ProcessSubmitAttendance(int playerId, int gameId, AttendanceType attendanceType)
        {
            Player loggedInPlayer = _playerRepository.GetPlayerById(playerId);
            List<Game> allGames = _gameRepository.GetAll().ToList();
            var currentGame = allGames.Find(game => game.GameId == gameId);
            
            if (currentGame != null)
            {
                Attendee? attendee = currentGame.Attendees.Find(a => a.Name.Equals(loggedInPlayer.Name));
                if (attendee != null)
                {
                    attendee.IsPresent = (short)attendanceType;
                } else
                {
                    currentGame.Attendees.Add(PlayerConverter.ConvertToAttendee(loggedInPlayer, attendanceType));
                }
                
                _gameRepository.Update(currentGame);
                _gameRepository.SaveChanges();
            }

            return View("GetAll", new GameViewModel() { Games = allGames, LoggedInPlayer = loggedInPlayer });
        }
    }
}
