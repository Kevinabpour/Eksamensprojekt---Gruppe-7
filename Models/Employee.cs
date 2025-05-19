﻿using System.ComponentModel.DataAnnotations;

namespace Eksamensprojekt___Gruppe_7.Models

    // by Ahmed
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Navn er påkrævet.")]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "Telefonnummer er påkrævet.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email er påkrævet.")]
        [EmailAddress(ErrorMessage = "Ugyldig email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Jobtitel er påkrævet.")]
        public string JobTitle { get; set; }

        public Employee()
        {
            
        }

        public Employee(int id, string name, string picture, string phoneNumber, string email, string jobTitle)
        {
            Id = id;
            Name = name;
            Picture = picture;
            PhoneNumber = phoneNumber;
            Email = email;
            JobTitle = jobTitle;

        }
    }
}
