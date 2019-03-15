using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class Users
    {
        public Users()
        {
            AdventurerParty = new HashSet<AdventurerParty>();
            RequestingParty = new HashSet<RequestingParty>();
        }

        public int Id { get; set; }
        public int LoginInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public int? Strength { get; set; }
        public int? Dex { get; set; }
        public int? Wisdom { get; set; }
        public int? Intelligence { get; set; }
        public int? Charisma { get; set; }
        public int? Constitution { get; set; }
        public int? RankId { get; set; }

        public virtual LoginInfo LoginInfo { get; set; }
        public virtual Ranks Rank { get; set; }
        public virtual ICollection<AdventurerParty> AdventurerParty { get; set; }
        public virtual ICollection<RequestingParty> RequestingParty { get; set; }
    }
}
