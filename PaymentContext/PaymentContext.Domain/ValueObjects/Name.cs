using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsLowerThan(3, FirstName.Length, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .IsLowerThan(3, LastName.Length, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(40, FirstName.Length, "Name.FirstName", "Nome deve conter até 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}