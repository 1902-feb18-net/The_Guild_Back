using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public class Request
    {
        private decimal? _cost, _reward;
        private string _descript, _requirements;
        
        public int Id { get; set; }
        public int? RankId { get; set; }
        public int ProgressId { get; set; }

        public decimal? Cost
        {
            get => _cost;
            set
            {
                if (CheckConstraints.NonNegativeDecimal(value)) //allows setting null, 0, or positive
                { _cost = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public decimal? Reward
        {
            get => _reward;
            set
            {
                if (CheckConstraints.NonNegativeDecimal(value)) //allows setting null, 0, or positive
                { _reward = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Descript
        {
            get => _descript;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _descript = value;
            }
        }

        public string Requirements
        {
            get => _requirements;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _requirements = value;
            }
        }
    }
}
