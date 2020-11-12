using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JWTExample.Entities
{
    [Owned]
    public class RefreshToken
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsExprired => DateTime.Now >= ExpiredDate;
        public DateTime CreatedDate { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => RevokedDate == null && !IsExprired;
    }

}
