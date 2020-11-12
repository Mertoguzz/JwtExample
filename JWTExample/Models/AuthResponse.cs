using JWTExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JWTExample.Models
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JwtToken { get; set; }

        
        public string RefreshToken { get; set; }

        public AuthResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            Username = user.Username;
            Name = user.Name;
            Surname = user.Surname;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }

        
    }
}
