using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class CustomerViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Date { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public GenderViewModel Gender { get; set; }

        public LanguageViewModel Language { get; set; }

        public UserRoleViewModel UserRole { get; set; }

        //public UserTypeViewModel UserType { get; set; }

        public CustomerViewModel()
        {
            Gender = new GenderViewModel();
            Language = new LanguageViewModel();
            UserRole = new UserRoleViewModel();
            //UserType = new UserTypeViewModel();
        }
    }
}