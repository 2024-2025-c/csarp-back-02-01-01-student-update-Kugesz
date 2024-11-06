namespace Kreata.Backend.Datas.Entities
{
    public class Item
    {
        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Item()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nev: {Name}";
        }
    }
}
