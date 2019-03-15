using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
