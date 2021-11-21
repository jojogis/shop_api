using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api
{
    public enum UserRole { def, admin };

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
