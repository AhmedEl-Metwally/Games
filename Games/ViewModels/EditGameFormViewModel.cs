using Games.Attributes;

namespace Games.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        [AllowedExtentsionsAttributes(FileSettings.AllowedExtensions)
           , MaxFileSizeAttributes(FileSettings.MaxFileSizeInBytes)]

        public IFormFile? Cover { get; set; } = default!;
    }
}
