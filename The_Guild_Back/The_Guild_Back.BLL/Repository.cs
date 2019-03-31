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


        public async Task<int> AddUserAsync(Users users)
        {
            var mapped = Mapper.Map(users);
            _db.Add(mapped);
            await _db.SaveChangesAsync();
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
            var mapped = Mapper.Map(user);
            var current = await _db.Users.FindAsync(user.Id);

            if(mapped.RankId != current.RankId) //if they're trying to rank up
            {
                var requirements = await _db.RankRequirements.FindAsync(current.RankId);

                //minimum total stats check
                int userStats = 0;
                userStats += mapped.Charisma ?? 0;
                userStats += mapped.Constitution ?? 0;
                userStats += mapped.Dex ?? 0;
                userStats += mapped.Intelligence ?? 0;
                userStats += mapped.Strength ?? 0;
                userStats += mapped.Wisdom ?? 0;
                if(userStats < requirements.MinTotalStats)
                {
                    throw new ArgumentException("User doesn't have high enough stats to rank up.");
                }

                //number of completed requests check
                var requests = _db.AdventurerParty.Include(p=> p.Request).ThenInclude(r => r.Progress)
                    .Where(p => p.AdventurerId == user.Id && p.Request.Progress.Nam == "Completed");

                if(requests.Count() < requirements.NumberRequests)
                {
                    throw new ArgumentException("User doesn't have enough completed requests to rank up.");
                }
            }

            _db.Entry(current).CurrentValues.SetValues(mapped);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Request> GetSubmittedRequestsByUserId(int id)
        {
            var reqs = _db.Request.Include(o => o.RequestingGroup)
            .Where(r => r.RequestingGroup.Where(rg => rg.CustomerId == id).Count() != 0).ToList();

            return Mapper.Map(reqs);
        }

        public IEnumerable<Request> GetAcceptedRequestsByUserId(int id)
        {
            var reqs = _db.Request.Include(o => o.AdventurerParty)
            .Where(r => r.AdventurerParty.Where(rg => rg.AdventurerId == id).Count() != 0).ToList();

            return Mapper.Map(reqs);
        }

        public async Task<RankRequirements> GetRankRequirementsByCurrentRankIdAsync(int id)
        {
            if (_db.RankRequirements.Count() == 0) //if empty, firstasync threw an error
                return null;

            var rankReq = await _db.RankRequirements.FirstAsync(r => r.CurrentRankId == id); //should only be one

            if (rankReq == null)
                return null;
            else
                return Mapper.Map(rankReq);
        }


        public async Task<int> AddRequestAsync(Request obj)
        {
            var mapped = Mapper.Map(obj);
            mapped.ProgressId = 1; //set new dbRequest to pending

            if(mapped.RankId != null)
            {
                var rank = await _db.Ranks.FindAsync(mapped.RankId);
                mapped.Cost = rank?.Fee;  //if rank is null, there will be 
                //a problem on adding to the db right? Cause FK Referential Integrity
            }

            _db.Add(mapped);
            await _db.SaveChangesAsync();
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
            var mapped = Mapper.Map(request);
            if (mapped.RankId != null)
            {
                var rank = _db.Ranks.Find(mapped.RankId); //can return null
                mapped.Cost = rank?.Fee;  //if rank is null, there will be 
                //a problem on updating the db right? Cause FK Referential Integrity
            }
            _db.Entry(_db.Request.Find(request.Id)).CurrentValues.SetValues(mapped);
            _db.SaveChanges();
        }
        public async Task UpdateRequestAsync(Request request)
        {
            var mapped = Mapper.Map(request);
            //add checks for updating fields depending on request's progress. Make sure to change tests as well.

            if (mapped.RankId != null) //only do this in some cases
            {
                var rank = await _db.Ranks.FindAsync(mapped.RankId); //can return null
                mapped.Cost = rank?.Fee;  //if rank is null, there will be 
                //a problem on updating the db right? Cause FK Referential Integrity
            }

            var currentReq = await _db.Request.FindAsync(request.Id);
            if(currentReq.ProgressId > mapped.ProgressId) //assumes we won't change what the preset progress in db are
            {
                throw new ArgumentException("Request's progress cannot go backwards!"); //cannot set progress backwards
            }

            _db.Entry(currentReq).CurrentValues.SetValues(mapped);
            await _db.SaveChangesAsync();
        }


        public async Task<int> AddProgressAsync(Progress obj)
        {
            var mapped = Mapper.Map(obj);
            _db.Add(mapped);
            await _db.SaveChangesAsync();
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


        public async Task<int> AddAdventurerPartyAsync(AdventurerParty adventurerParty)
        {
            var mapped = Mapper.Map(adventurerParty);
            _db.Add(mapped);
            await _db.SaveChangesAsync();
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



        public async Task<int> AddRequestingGroupAsync(RequestingGroup requestingGroup)
        {
            var mapped = Mapper.Map(requestingGroup);
            _db.Add(mapped);
            await _db.SaveChangesAsync();
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



        public async Task<int> AddRankAsync(Ranks rank)
        {
            var mapped = Mapper.Map(rank);
            _db.Add(mapped);
            await _db.SaveChangesAsync();
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


        public async Task<int> AddRankRequirementsAsync(RankRequirements rankReq)
        {
            var mapped = Mapper.Map(rankReq);

            //Logic to prevent adding a rankrequirements if one for the current rank already exists.
            var check = await _db.RankRequirements.FindAsync(mapped.CurrentRankId);
            if (check != null) //if there is a result
            { throw new ArgumentException("Rank-up requirements for given rank already exist."); }

            _db.Add(mapped);
            await _db.SaveChangesAsync();
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
            //Need logic to prevent updating a rankrequirements if one for the new current rank already exists.
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
