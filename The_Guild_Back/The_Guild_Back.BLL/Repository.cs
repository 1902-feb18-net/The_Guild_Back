﻿using Microsoft.EntityFrameworkCore;
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





        public void AddProgress(Progress progress)
        {
            _db.Add(Mapper.Map(progress));
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




        public void AddAdventurerParty(AdventurerParty adventurerParty)
        {
            _db.Add(Mapper.Map(adventurerParty));
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