using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DoctorBooking.App_Code;

namespace DoctorBooking.App_Code
{
    public abstract class Person :Page
    {
        public string IdCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        public Person() { }

        public Person(string idCard, string firstName, string lastName, DateTime dateOfBirth, string address, string city, string email, string phone, string gender)
        {
            IdCard = idCard;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            City = city;
            Email = email;
            Phone = phone;
            Gender = gender;
        }
    }
}