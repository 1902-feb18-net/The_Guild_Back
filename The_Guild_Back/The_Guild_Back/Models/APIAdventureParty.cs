using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Guild_Back.API.Models
{
    public class ApiAdventureParty
    {
        [Required]
        public string Name { get; set; }

        public int Id { get; set; }
        public int AdventurerId { get; set; }
        public int RequestId { get; set; }
    }
}
