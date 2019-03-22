using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Request GetRequestById(int id)
        {
            return Mapper.Map(_db.Request.AsNoTracking().First(r => r.Id == id));
        }

        public void DeleteRequest(int Id)
        {
            _db.Remove(_db.Request.Find(Id));
        }

        public void UpdateRequest(Request request)
        {
            _db.Entry(_db.Request.Find(request.Id)).CurrentValues.SetValues(Mapper.Map(request));
        }



        public int AddProgress(Progress obj)
        {
            var mapped = Mapper.Map(obj);
            _db.Add(mapped);
            return mapped.Id;
        }

        public IEnumerable<Progress> GetAllProgress()
        {
            return Mapper.Map(_db.Progress);
        }

        public Progress GetProgressById(int id)
        {
            return Mapper.Map(_db.Progress.AsNoTracking().First(p => p.Id == id));
        }
        public void UpdateProgress(Progress progress)
        {
            _db.Entry(_db.Progress.Find(progress.Id)).CurrentValues.SetValues(Mapper.Map(progress));
        }




        public int AddAdventurerParty(AdventurerParty adventurerParty)
        {
            var mapped = Mapper.Map(adventurerParty);
            _db.Add(mapped);
            return mapped.Id;
        }
        public IEnumerable<AdventurerParty> GetAllAdventurerParties()
        {
            return Mapper.Map(_db.AdventurerParty);
        }

        public AdventurerParty GetAdventurerPartyById(int id)
        {
            return Mapper.Map(_db.AdventurerParty.AsNoTracking().First(p => p.Id == id));
        }

        public void UpdateAdventurerParty(AdventurerParty adventurerParty)
        {
            _db.Entry(_db.Request.Find(adventurerParty.Id)).CurrentValues.SetValues(Mapper.Map(adventurerParty));
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
