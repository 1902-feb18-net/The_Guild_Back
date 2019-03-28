using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class Ranks
    {
        private string _name;
        private decimal _fee;

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

        public decimal Fee
        {
            get => _fee;
            set
            {
                if (CheckConstraints.NonNegativeDecimal(value)) //allows setting null, 0, or positive
                { _fee = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }


    }
}
