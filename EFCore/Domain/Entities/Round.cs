using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class Round : BaseEntity
    {
        public int Number { get; set; }

        public Guid SeasonId { get; set; }
        public Season Season { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
