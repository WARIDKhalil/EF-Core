namespace EFCore.Domain.Entities
{
    public class Trainer : Person
    {
        public Club Club { get; set; }
    }
}
