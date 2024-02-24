using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Username { get; set; }
        [StringLength(40)]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
