using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class Club : BaseEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Slogan { get; set; }
        public DateTime EstablishmentDate { get; set; }

        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Game> GamesAway { get; set; }
        public IEnumerable<Game> GamesHome { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}
