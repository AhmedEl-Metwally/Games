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
            return View();
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
    }
}
