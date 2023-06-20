using EFCore.Domain.Enums;

namespace EFCore.Domain.Entities
{
    public class Player : Person
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public PlayerPosition Position { get; set; }

        public IEnumerable<Contract> Contracts { get; set;}
        public IEnumerable<PlayerStats> Stats { get; set; }

    }
}
