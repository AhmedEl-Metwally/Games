namespace Games.Models
{
    public class Game : BaseEntity
    {
        [MinLength(2500)]
        public string Description { get; set; } = string.Empty;

        [MinLength(500)]
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
