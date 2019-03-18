using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    class LoginInfo
    {
        private string _username;
        public int Id { get; set; }
        public string Username
        {
            get => _username;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _username = value;
            }
        }
        public string Pass { get; set; }
    }
}
