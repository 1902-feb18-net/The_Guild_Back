using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class ApiProgress
    {
        public int Id { get; set; }

        [Required]
        public string Nam { get; set; }

    }
}
