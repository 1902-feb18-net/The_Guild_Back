using System;
using System.Collections.Generic;
using System.Text;
using The_Guild_Back.DAL;

namespace The_Guild_Back.BLL
{
    public class UserRepo : IRepository
    {
        private readonly project2theGuildContext _db;

        public UserRepo(project2theGuildContext db)
        {
            _db = db;
        }

        public void AddUser(DAL.Users users)
        {
            _db.Add(Mapper.Map(users));
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return Mapper.Map(_db.Users);
        }

        
        public void DeleteUser(int Id)
        {
            _db.Remove(_db.Users.Find(Id));
        }


        public void AddLoginInfo(DAL.LoginInfo loginInfo)
        {
            _db.Add(Mapper.Map(loginInfo));
        }

        public IEnumerable<LoginInfo> GetAllLoginInfo()
        {
            return Mapper.Map(_db.LoginInfo);
        }

    }
}
