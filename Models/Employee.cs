namespace Eksamensprojekt___Gruppe_7.Models

    // by Ahmed
{
    public class Employee
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public Employee()
        {
            
        }

        public Employee(string name, string picture, string phoneNumber, string email, string jobTitle)
        {
            Name = name;
            Picture = picture;
            PhoneNumber = phoneNumber;
            Email = email;
            JobTitle = jobTitle;

        }
    }
}
