using System;
using System.Collections.Generic;
using System.Text;
using The_Guild_Back.DAL;

namespace The_Guild_Back.BLL
{
    public class Repository : IRepository
    {
        private readonly project2theGuildContext _db;

        public Repository(project2theGuildContext db)
        {
            _db = db;
        }


        public void AddUser(Users users)
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


        public void AddLoginInfo(LoginInfo loginInfo)
        {
            _db.Add(Mapper.Map(loginInfo));
        }

        public IEnumerable<LoginInfo> GetAllLoginInfo()
        {
            return Mapper.Map(_db.LoginInfo);
        }



        public void AddRequest(Request obj)
        {
            _db.Add(Mapper.Map(obj));
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return Mapper.Map(_db.Request);
        }

        public void DeleteRequest(int Id)
        {
            _db.Remove(_db.Request.Find(Id));
        }



    }
}
