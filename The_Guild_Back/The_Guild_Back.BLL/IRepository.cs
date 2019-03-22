using System;
using System.Collections.Generic;
using System.Text;

namespace The_Guild_Back.BLL
{
    public interface IRepository
    {
        void AddUser(DAL.Users users);

        void AddLoginInfo(DAL.LoginInfo loginInfo);

        IEnumerable<Users> GetAllUsers();
        IEnumerable<LoginInfo> GetAllLoginInfo();



    }

   


}
