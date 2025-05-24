namespace Eksamensprojekt___Gruppe_7.Models
{
    //By Kevin

    // Event model
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // List of Participants
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }

    // Participant model
    public class Participant
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
