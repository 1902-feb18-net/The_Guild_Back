using System;
using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public class RankRequirements
    {
        public int Id { get; set; }
        public int CurrentRankId { get; set; }
        public int NumberRequests { get; set; }
        public int MinTotalStats { get; set; }
        public int NextRankId { get; set; }

        
    }
}
