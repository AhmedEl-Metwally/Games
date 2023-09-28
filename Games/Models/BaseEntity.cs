namespace Games.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [MinLength(250), Required]
        public string Name { get; set; }

    }
}
