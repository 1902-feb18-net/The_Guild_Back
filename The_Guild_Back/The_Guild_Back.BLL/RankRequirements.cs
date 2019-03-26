using System;
using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public class RankRequirements
    {
        private int _numberRequests, _minTotalStats;

        public int Id { get; set; }
        public int CurrentRankId { get; set; }
        public int NextRankId { get; set; }

        public int NumberRequests
        {
            get => _numberRequests;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _numberRequests = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int MinTotalStats
        {
            get => _minTotalStats;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _minTotalStats = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }


    }
}
