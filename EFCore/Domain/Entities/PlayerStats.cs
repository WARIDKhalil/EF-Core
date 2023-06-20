using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class PlayerStats : BaseEntity
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int OwnGoals { get; set; }
        public int Minutesplayed { get; set; }
        public bool IsStratingPlayer { get; set; }
        public bool IsSubstitutionPlayer { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
