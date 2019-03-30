using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Guild_Back.API.Models
{
    public class ApiAccountDetails
    {
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public int UserId { get; set; }
    }
}
