namespace Games.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGamesServices _gamesServices;


        public GamesController(ICategoriesServices categoriesServices , IDevicesServices devicesServices 
                               , IGamesServices gamesServices)
        {
            _categoriesServices = categoriesServices; 
            _devicesServices = devicesServices; 
            _gamesServices = gamesServices;

        }

        public IActionResult Index()
        {
            var games = _gamesServices.GetAll();

            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesServices.GetById(id);

            if(game is null)
                return NotFound();  

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetSelectLists(),
                Devices = _devicesServices.GetSelectLists(),    
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectLists();
                model.Devices = _devicesServices.GetSelectLists();

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
                Categories = _categoriesServices.GetSelectLists(),
                Devices = _categoriesServices.GetSelectLists(),
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
                model.Categories = _categoriesServices.GetSelectLists();
                model.Devices = _devicesServices.GetSelectLists();

                return View(model);
            }

            var game = await _gamesServices.Update(model);  

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
           var isDelete = _gamesServices.Delete(id);   

            return isDelete ? Ok() : BadRequest();
        }
    }
}
