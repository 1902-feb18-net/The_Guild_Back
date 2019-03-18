using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class Users
    {
        private string _firstName, _lastName;

        public int Id { get; set; }
        public int LoginInfoId { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _lastName = value;
            }
        }
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
