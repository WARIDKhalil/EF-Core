namespace EFCore.Domain.Entities
{
    public class Referee : Person
    {
        public IEnumerable<Game> Games { get; set; }
    }
}
