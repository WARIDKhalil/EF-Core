using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class Season : BaseEntity
    {
        public string Years { get; set; }

        public IEnumerable<Round> Rounds { get; set; }
        public IEnumerable<Club> Clubs { get; set; }
    }
}
