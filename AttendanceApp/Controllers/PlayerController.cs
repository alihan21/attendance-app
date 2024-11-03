using AttendanceApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IActionResult GetAllPlayers()
        {
            var players = _playerRepository.GetAllPlayers();
            return View(players);
        }
    }
}
