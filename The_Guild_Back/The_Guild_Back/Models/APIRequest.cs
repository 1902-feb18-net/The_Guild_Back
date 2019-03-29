using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class ApiRequest
    {
        public int Id { get; set; }
        public int? RankId { get; set; }

        [Required]
        public string Descript { get; set; }

        [Required]
        public string Requirements { get; set; }

        [Range(0.00, 900000.00)]
        public decimal? Reward { get; set; }

        [Range(0.00, 900000.00)]
        public decimal? Cost { get; set; }
        public int ProgressId { get; set; } // ?

        public List<Users> Requesters { get; set; } = new List<Users>();
    }
}
