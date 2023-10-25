using Microsoft.AspNetCore.Authorization;

namespace GameZone.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class GamesController : Controller
    {
        private readonly IDevicesService _devicesService;
        private readonly ICategoriesService _categoriesServices;
        private readonly IGamesService _gamesServices;
        public GamesController(ICategoriesService categoriesServices,
            IDevicesService devicesService, IGamesService gamesService)
        {
            _categoriesServices = categoriesServices;
            _devicesService = devicesService;
            _gamesServices = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesServices.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesServices.GetById(id);

            if (game is null)
                return NotFound();

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // To Show List Item to view page

            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetSelectList(),

                Devices = _devicesService.GetSelectList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectList();
                model.Devices =_devicesService.GetSelectList();
                return View(model);
            }
            await _gamesServices.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesServices.GetById(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesServices.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                CurrentCover = game.Cover
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectList();
                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }
            
            var game = await _gamesServices.Edit(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var isDeleted = _gamesServices.Delete(id);

            return isDeleted ?  Ok() : BadRequest();
        }

    }
}
