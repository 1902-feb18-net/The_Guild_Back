using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class LoginInfo
    {
        private string _username;
        private string _password;

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
        public string Pass
        {
            get => _password;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _password = value;
            }
        }
    }
}
