
namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesService _gamesServices;

        public HomeController(IGamesService gamesSrevices)
        {
            _gamesServices = gamesSrevices;
        }

        public IActionResult Index()
        {
            var games = _gamesServices.GetAll();
            return View(games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}