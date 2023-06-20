using EFCore.Domain.Abstractions;

namespace EFCore.Domain.Entities
{
    public class Contract : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double SalaryPerYear { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid ClubId { get; set; }
        public Club Club { get; set; }
    }
}
