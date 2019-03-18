using System;
using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public class Users
    {
        

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

        
    }
}
