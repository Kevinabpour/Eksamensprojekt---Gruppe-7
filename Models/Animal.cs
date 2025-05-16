namespace Eksamensprojekt___Gruppe_7.Models
{
    public class Animal
    {

        private static int _tempID = 0;
        string _name;
        string _chipNumber;
        string _text;
        string _picture;
        bool _avaliability;
        int _id;
        List<string> _defect;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ChipNumber
        {
            get { return _chipNumber; }
            set { _chipNumber = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
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
            _chipNumber = "test";
            _text = "test";
            _picture = "test";
            _avaliability = true;
            _id = _tempID++;
            Defect = new List<string>(); // by Ahmed

        }
        public Animal(string name, string chipnumber, string text, string picture) : this()
        {
            _name = name;
            _chipNumber = chipnumber;
            _text = text;
            _picture = picture;
        }
        public Animal(string name, string chipnumber, string text, string picture, bool avaliabilty) : this(name, chipnumber, text, picture)
        {
            _avaliability = avaliabilty;

        }
    }
}
