using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class Ranks
    {
        private string _name;

        public int Id { get; set; }
        public string Nam
        {
            get => _name;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _name = value;
            }
        }
        public decimal Fee { get; set; }

        
    }
}
