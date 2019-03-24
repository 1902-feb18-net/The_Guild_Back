using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class APILogininfo
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Pass { get; set; }

        public IEnumerable<Users> Users { get; set; }
    }
}
