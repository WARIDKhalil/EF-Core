using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class Game : BaseEntity
    {
        public DateTime GameDate { get; set; }

        public Guid RoundId { get; set; }
        public Round Round { get; set; }
        public Guid ClubAwayId { get; set; }
        public Club ClubAway { get; set; }
        public Guid ClubHomeId { get; set; }
        public Club ClubHome { get; set; }
        public IEnumerable<Referee> Referees { get; set; }
        public IEnumerable<PlayerStats> Stats { get; set;}
    }
}
