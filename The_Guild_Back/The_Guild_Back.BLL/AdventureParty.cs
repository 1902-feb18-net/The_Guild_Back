using System;
using System.Collections.Generic;
using System.Text;

namespace The_Guild_Back.BLL
{
    class AdventureParty
    {
        public int Id { get; set; }
        public string Nam { get; set; }
        public int? AdventurerId { get; set; }
        public int? RequestId { get; set; }
    }
}
