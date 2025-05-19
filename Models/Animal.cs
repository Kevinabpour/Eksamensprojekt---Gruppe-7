namespace Eksamensprojekt___Gruppe_7.Models
//By Kevin
{
    public class Animal
    {

        private static int _tempID = 0;
        string _name;
        int _size;
        string _chipNumber;
        string _race;
        string _characteristics;
        string _picture;
        bool _avaliability;
        int _id;
        List<string> _defect;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string ChipNumber
        {
            get { return _chipNumber; }
            set { _chipNumber = value; }
        }
        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }
        public string Characteristics
        {
            get { return _characteristics; }
            set { _characteristics = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public bool Avaliability
        {
            get { return _avaliability; }
            set { _avaliability = value; }
        }
        public List<string> Defect
        {
            get { return _defect; }
            set { _defect = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Animal()
        {
            _name = "test";
            _size = 0;
            _chipNumber = "test";
            _race = "test";
            _picture = "test";
            _avaliability = true;
            _id = _tempID++;
            Defect = new List<string>(); // by Ahmed

        }
        public Animal(string name, int size, string chipnumber, string race, string characteristics, string picture) : this()
        {
            _name = name;
            _size = size;
            _chipNumber = chipnumber;
            _race = Race;
            _characteristics = characteristics;
            _picture = picture;
        }
        public Animal(string name, int size, string chipnumber, string race, string characteristics, string picture, bool avaliabilty) : this(name, size, chipnumber, race, characteristics, picture)
        {
            _avaliability = avaliabilty;

        }
    }
}
