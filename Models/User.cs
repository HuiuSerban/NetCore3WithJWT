using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJWT.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JWT { get; set; }

        public User() { }
        public User(Guid id, string email, string password, string firsName, string lastName)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firsName;
            LastName = lastName;
        }
    }
}
