using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class Ranks
    {
        public Ranks()
        {
            RankRequirementsCurrentRank = new HashSet<RankRequirements>();
            RankRequirementsNextRank = new HashSet<RankRequirements>();
            Request = new HashSet<Request>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Nam { get; set; }
        public decimal Fee { get; set; }

        public virtual ICollection<RankRequirements> RankRequirementsCurrentRank { get; set; }
        public virtual ICollection<RankRequirements> RankRequirementsNextRank { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
