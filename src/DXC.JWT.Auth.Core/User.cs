using System;

namespace DXC.JWT.Auth.Core
{
    public class User
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}