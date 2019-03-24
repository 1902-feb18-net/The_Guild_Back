using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class APIUsers
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Range(0, 900000)]
        public decimal? Salary { get; set; }


        [Range(0, 40)]
        public int? Strength { get; set; }

        [Range(0, 40)]
        public int? Dex { get; set; }

        [Range(0, 40)]
        public int? Wisdom { get; set; }

        [Range(0, 40)]
        public int? Intelligence { get; set; }

        [Range(0, 40)]
        public int? Charisma { get; set; }

        [Range(0, 40)]
        public int? Constitution { get; set; }

        public int? RankId { get; set; }
    }
}
