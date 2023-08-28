
namespace Games.Models
{
    public class Device : BaseEntity
    {
        [MinLength(50)]
        public string Icon { get; set; } = string.Empty;
    }
}
