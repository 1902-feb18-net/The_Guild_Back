﻿using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class AdventurerParty
    {
        private string _name;
        public int Id { get; set; }
        public int? AdventurerId { get; set; }
        public int? RequestId { get; set; }

        public string Nam {
            get => _name;
            set {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _name = value; }
        }

    }
}
