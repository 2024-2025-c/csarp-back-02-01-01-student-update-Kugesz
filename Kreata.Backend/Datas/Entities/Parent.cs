using Kreata.Backend.Datas.Enums;

namespace Kreata.Backend.Datas.Entities
{
    public class Parent
    {
        public Parent(Guid id, string firstName, string lastName, string address, bool isWooman)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsWoomen = isWooman;
        }

        public Parent()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            IsWoomen = false;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address {  get; set; }
        public bool IsWoomen { get; set; }
        public override string ToString()
        {
            string nem = IsWoomen ? "nő" : "férfi";
            return $"{LastName} {FirstName}  Lakcím: ${Address} Nem: ${nem}";
        }
    }
}
