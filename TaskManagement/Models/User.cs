using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public User()
        {

        }

        public User(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }


    }
}
