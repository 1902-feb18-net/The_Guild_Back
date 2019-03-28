using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _db.SaveChanges();
            return mapped.Id;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return Mapper.Map(_db.Users);
        }

        public Users GetUserById(int id)
        {
            return Mapper.Map(_db.Users.AsNoTracking().First(r => r.Id == id));
        }
        public async Task<Users> GetUserByIdAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
                return null;
            else
                return Mapper.Map(user);
        }

        public void DeleteUser(int Id)
        {
            _db.Remove(_db.Users.Find(Id));
            _db.SaveChanges();
        }
        public async Task DeleteUserAsync(int Id)
        {
            _db.Remove(await _db.Users.FindAsync(Id));
            await _db.SaveChangesAsync();
        }

        public void UpdateUser(Users user)
        {
            _db.Entry(_db.Users.Find(user.Id)).CurrentValues.SetValues(Mapper.Map(user));
            _db.SaveChanges();
        }
        public async Task UpdateUserAsync(Users user)
        {
            _db.Entry(await _db.Users.FindAsync(user.Id)).CurrentValues.SetValues(Mapper.Map(user));
            await _db.SaveChangesAsync();
        }



        public int AddRequest(Request obj)
        {
            var mapped = Mapper.Map(obj);
            mapped.ProgressId = 1; //set new dbRequest to pending
            _db.Add(mapped);
            _db.SaveChanges();
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
        public async Task<Request> GetRequestByIdAsync(int id)
        {
            var Request = await _db.Request.FindAsync(id);
            if (Request == null)
                return null;
            else
                return Mapper.Map(Request);
        }

        public void DeleteRequest(int Id)
        {
            _db.Remove(_db.Request.Find(Id));
            _db.SaveChanges();
        }
        public async Task DeleteRequestAsync(int Id)
        {
            _db.Remove(await _db.Request.FindAsync(Id));
            await _db.SaveChangesAsync();
        }

        public void UpdateRequest(Request request)
        {
            _db.Entry(_db.Request.Find(request.Id)).CurrentValues.SetValues(Mapper.Map(request));
            _db.SaveChanges();
        }
        public async Task UpdateRequestAsync(Request request)
        {
            _db.Entry(await _db.Request.FindAsync(request.Id)).CurrentValues.SetValues(Mapper.Map(request));
            await _db.SaveChangesAsync();
        }


        public int AddProgress(Progress obj)
        {
            var mapped = Mapper.Map(obj);
            _db.Add(mapped);
            _db.SaveChanges();
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
        public async Task<Progress> GetProgressByIdAsync(int id)
        {
            var Progress = await _db.Progress.FindAsync(id);
            if (Progress == null)
                return null;
            else
                return Mapper.Map(Progress);
        }

        public void UpdateProgress(Progress progress)
        {
            _db.Entry(_db.Progress.Find(progress.Id)).CurrentValues.SetValues(Mapper.Map(progress));
            _db.SaveChanges();
        }
        public async Task UpdateProgressAsync(Progress progress)
        {
            _db.Entry(await _db.Progress.FindAsync(progress.Id)).CurrentValues.SetValues(Mapper.Map(progress));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProgressAsync(int Id)
        {
            _db.Remove(await _db.Progress.FindAsync(Id));
            await _db.SaveChangesAsync();
        }


        public int AddAdventurerParty(AdventurerParty adventurerParty)
        {
            var mapped = Mapper.Map(adventurerParty);
            _db.Add(mapped);
            _db.SaveChanges();
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
        public async Task<AdventurerParty> GetAdventurerPartyByIdAsync(int id)
        {
            var AdventurerParty = await _db.AdventurerParty.FindAsync(id);
            if (AdventurerParty == null)
                return null;
            else
                return Mapper.Map(AdventurerParty);
        }

        public void UpdateAdventurerParty(AdventurerParty adventurerParty)
        {
            _db.Entry(_db.AdventurerParty.Find(adventurerParty.Id)).CurrentValues.SetValues(Mapper.Map(adventurerParty));
            _db.SaveChanges();
        }
        public async Task UpdateAdventurerPartyAsync(AdventurerParty adventurerParty)
        {
            _db.Entry(await _db.AdventurerParty.FindAsync(adventurerParty.Id)).CurrentValues.SetValues(Mapper.Map(adventurerParty));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAdventurerPartyAsync(int Id)
        {
            _db.Remove(await _db.AdventurerParty.FindAsync(Id));
            await _db.SaveChangesAsync();
        }



        public int AddRequestingGroup(RequestingGroup requestingGroup)
        {
            var mapped = Mapper.Map(requestingGroup);
            _db.Add(mapped);
            _db.SaveChanges();
            return mapped.Id;
        }

        public IEnumerable<RequestingGroup> GetAllRequestingGroups()
        {
            return Mapper.Map(_db.RequestingGroup);
        }

        public async Task<RequestingGroup> GetRequestingGroupByIdAsync(int id)
        {
            var RequestingGroup = await _db.RequestingGroup.FindAsync(id);
            if (RequestingGroup == null)
                return null;
            else
                return Mapper.Map(RequestingGroup);
        }

        public void UpdateRequestingGroup(RequestingGroup RequestingGroup)
        {
            _db.Entry(_db.RequestingGroup.Find(RequestingGroup.Id)).CurrentValues.SetValues(Mapper.Map(RequestingGroup));
            _db.SaveChanges();
        }
        public async Task UpdateRequestingGroupAsync(RequestingGroup RequestingGroup)
        {
            _db.Entry(await _db.RequestingGroup.FindAsync(RequestingGroup.Id)).CurrentValues.SetValues(Mapper.Map(RequestingGroup));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRequestingGroupAsync(int Id)
        {
            _db.Remove(await _db.RequestingGroup.FindAsync(Id));
            await _db.SaveChangesAsync();
        }



        public int AddRank(Ranks rank)
        {
            var mapped = Mapper.Map(rank);
            _db.Add(mapped);
            _db.SaveChanges();
            return mapped.Id;
        }

        public IEnumerable<Ranks> GetAllRanks()
        {
            return Mapper.Map(_db.Ranks);
        }

        public async Task<Ranks> GetRankByIdAsync(int id)
        {
            var Rank = await _db.Ranks.FindAsync(id);
            if (Rank == null)
                return null;
            else
                return Mapper.Map(Rank);
        }

        public void UpdateRank(Ranks Rank)
        {
            _db.Entry(_db.Ranks.Find(Rank.Id)).CurrentValues.SetValues(Mapper.Map(Rank));
            _db.SaveChanges();
        }
        public async Task UpdateRankAsync(Ranks Rank)
        {
            _db.Entry(await _db.Ranks.FindAsync(Rank.Id)).CurrentValues.SetValues(Mapper.Map(Rank));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRankAsync(int Id)
        {
            _db.Remove(await _db.Ranks.FindAsync(Id));
            await _db.SaveChangesAsync();
        }


        public int AddRankRequirements(RankRequirements rankReq)
        {
            var mapped = Mapper.Map(rankReq);
            _db.Add(mapped);
            _db.SaveChanges();
            return mapped.Id;
        }

        public IEnumerable<RankRequirements> GetAllRankRequirements()
        {
            return Mapper.Map(_db.RankRequirements);
        }

        public async Task<RankRequirements> GetRankRequirementsByIdAsync(int id)
        {
            var RankRequirements = await _db.RankRequirements.FindAsync(id);
            if (RankRequirements == null)
                return null;
            else
                return Mapper.Map(RankRequirements);
        }

        public void UpdateRankRequirements(RankRequirements RankRequirements)
        {
            _db.Entry(_db.RankRequirements.Find(RankRequirements.Id)).CurrentValues.SetValues(Mapper.Map(RankRequirements));
            _db.SaveChanges();
        }
        public async Task UpdateRankRequirementsAsync(RankRequirements RankRequirements)
        {
            _db.Entry(await _db.RankRequirements.FindAsync(RankRequirements.Id)).CurrentValues.SetValues(Mapper.Map(RankRequirements));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRankRequirementsAsync(int Id)
        {
            _db.Remove(await _db.RankRequirements.FindAsync(Id));
            await _db.SaveChangesAsync();
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
