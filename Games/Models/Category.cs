namespace Games.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
