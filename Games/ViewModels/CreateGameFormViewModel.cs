using Games.Attributes;

namespace Games.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
        [AllowedExtentsionsAttributes(FileSettings.AllowedExtensions) 
            , MaxFileSizeAttributes(FileSettings.MaxFileSizeInBytes)]

        public IFormFile Cover { get; set; } = default!;
    }
}
