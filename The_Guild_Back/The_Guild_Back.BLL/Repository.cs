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


        public int AddUser(Users users)
        {
            var mapped = Mapper.Map(users);
            _db.Add(mapped);
            return mapped.Id;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return Mapper.Map(_db.Users);
        }
        
        public void DeleteUser(int Id)
        {
            _db.Remove(_db.Users.Find(Id));
        }


        public int AddLoginInfo(LoginInfo loginInfo)
        {
            var mapped = Mapper.Map(loginInfo);
             _db.Add(mapped);
            return mapped.Id;
        }

        public IEnumerable<LoginInfo> GetAllLoginInfo()
        {
            return Mapper.Map(_db.LoginInfo);
        }



        public int AddRequest(Request obj)
        {
            var mapped = Mapper.Map(obj);
            _db.Add(mapped);
            return mapped.Id;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return Mapper.Map(_db.Request);
        }

        public void DeleteRequest(int Id)
        {
            _db.Remove(_db.Request.Find(Id));
        }

        public void Save()
        {
            _db.SaveChanges();
        }


        public int AddProgress(Progress obj)
        {
            var mapped = Mapper.Map(obj);
            _db.Add(mapped);
            return mapped.Id;
        }

    }
}
