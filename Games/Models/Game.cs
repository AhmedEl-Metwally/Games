namespace Games.Models
{
    public class Game : BaseEntity
    {
        [MinLength(2500)]
        public string Description { get; set; }

        [MinLength(500)]
        public string Cover { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
