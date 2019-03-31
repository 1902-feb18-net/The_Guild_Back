using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Guild_Back.API.Models
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
