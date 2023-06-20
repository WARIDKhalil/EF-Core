using EFCore.Domain.Abstractions;
using EFCore.Domain.Enums;

namespace EFCore.Domain.Entities
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sexe Sexe { get; set; }
    }
}
