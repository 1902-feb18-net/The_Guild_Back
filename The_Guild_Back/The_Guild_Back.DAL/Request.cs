using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class Request
    {
        public Request()
        {
            AdventurerParty = new HashSet<AdventurerParty>();
            RequestingParty = new HashSet<RequestingParty>();
        }

        public int Id { get; set; }
        public int? RankId { get; set; }
        public string Descript { get; set; }
        public string Requirements { get; set; }
        public decimal? Reward { get; set; }
        public decimal? Cost { get; set; }
        public int? ProgressId { get; set; }

        public virtual Progress Progress { get; set; }
        public virtual Ranks Rank { get; set; }
        public virtual ICollection<AdventurerParty> AdventurerParty { get; set; }
        public virtual ICollection<RequestingParty> RequestingParty { get; set; }
    }
}
