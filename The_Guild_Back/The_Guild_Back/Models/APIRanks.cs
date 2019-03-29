using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class ApiRanks
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.00, 900000.00)]
        public decimal Fee { get; set; }

    }
}
