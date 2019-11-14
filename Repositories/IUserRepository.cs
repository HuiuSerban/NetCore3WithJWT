using CoreJWT.Models;
using CoreJWT.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJWT.Repositories
{
    interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User Authenticate(string email, string password);
        void CreateUser(UserDTO userDTO);
    }
}
