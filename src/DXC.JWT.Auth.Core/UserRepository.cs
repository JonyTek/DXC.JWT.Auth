using System;
using System.Collections.Generic;

namespace DXC.JWT.Auth.Core
{
    public class UserRepository : IUserRepository
    {
        private static readonly Dictionary<string, User> users = new Dictionary<string, User>
        {
            {
                "jonathontek@gmail.com", new User
                {
                    Id = Guid.Parse("e54dd29d-8cc4-447e-8e9b-ead0c5a5fd85"),
                    Email = "jonathontek@gmail.com",
                    Password = "p@ssw0rd",
                    Fullname = "Jonathan Swieboda"
                }
            }
        };

        public User FindUserBy(string email)
        {
            return users.ContainsKey(email.ToLower()) ? users[email.ToLower()] : null;
        }
    }
}