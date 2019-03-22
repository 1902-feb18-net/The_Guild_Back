using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class AdventurerParty
    {
        public int Id { get; set; }
        public string Nam { get; set; }
        public int AdventurerId { get; set; }
        public int RequestId { get; set; }

        public virtual Users Adventurer { get; set; }
        public virtual Request Request { get; set; }
    }
}
