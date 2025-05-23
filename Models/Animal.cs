namespace Eksamensprojekt___Gruppe_7.Models
{
    public class Animal
    {
        private static int _tempID = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Size { get; set; }
        public string ChipNumber { get; set; }
        public string Race { get; set; }
        public string Characteristics { get; set; }
        public string Picture { get; set; }
        public bool Avaliability { get; set; }
        public List<string> Defect { get; set; }

        public Animal()
        {
            Id = _tempID++;
            Name = "test";
            Size = 0;
            ChipNumber = "test";
            Race = "test";
            Picture = "test";
            Avaliability = true;
            Characteristics = "";
            Defect = new List<string>();
        }

        public Animal(string name, DateTime birthdate, int size, string chipnumber, string race, string characteristics, string picture)
            : this()
        {
            Name = name;
            BirthDate = birthdate;
            Size = size;
            ChipNumber = chipnumber;
            Race = race;
            Characteristics = characteristics;
            Picture = picture;
        }

        public Animal(string name, DateTime birthdate, int size, string chipnumber, string race, string characteristics, string picture, bool avaliabilty)
            : this(name, birthdate, size, chipnumber, race, characteristics, picture)
        {
            Avaliability = avaliabilty;
        }
    }
}