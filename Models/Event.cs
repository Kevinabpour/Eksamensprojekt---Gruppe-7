namespace Eksamensprojekt___Gruppe_7.Models
{
    public class Event
    {
        string _name;
        string _picture;
        DateTime _startTime;
        DateTime _endTime;
        string _location;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public Event()
        {
            _name = "test";
            _picture = "test.png";
            _startTime = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
            _endTime = _startTime.AddHours(1);
            _location = "test";
        }
        public Event(string name, string picture, DateTime start, DateTime end, string location) : this()
        {
            _name = name;
            _picture = picture;
            _startTime = start;
            _endTime = end;
            _location = location;

        }



    }
}
