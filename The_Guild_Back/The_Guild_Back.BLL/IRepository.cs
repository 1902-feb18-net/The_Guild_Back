﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace The_Guild_Back.BLL
{
    public interface IRepository
    {
        Task<int> AddAdventurerPartyAsync(AdventurerParty adventurerParty);
        Task<int> AddProgressAsync(Progress obj);
        Task<int> AddRankAsync(Ranks rank);
        Task<int> AddRankRequirementsAsync(RankRequirements rankReq);
        Task<int> AddRequestAsync(Request obj);
        Task<int> AddRequestingGroupAsync(RequestingGroup requestingGroup);
        Task<int> AddUserAsync(Users users);
        Task DeleteAdventurerPartyAsync(int Id);
        Task DeleteProgressAsync(int Id);
        Task DeleteRankAsync(int Id);
        Task DeleteRankRequirementsAsync(int Id);
        void DeleteRequest(int Id);
        Task DeleteRequestAsync(int Id);
        Task DeleteRequestingGroupAsync(int Id);
        void DeleteUser(int Id);
        Task DeleteUserAsync(int Id);
        AdventurerParty GetAdventurerPartyById(int id);
        Task<AdventurerParty> GetAdventurerPartyByIdAsync(int id);
        IEnumerable<AdventurerParty> GetAllAdventurerParties();
        IEnumerable<Progress> GetAllProgress();
        IEnumerable<RankRequirements> GetAllRankRequirements();
        IEnumerable<Ranks> GetAllRanks();
        IEnumerable<RequestingGroup> GetAllRequestingGroups();
        IEnumerable<Request> GetAllRequests();
        IEnumerable<Users> GetAllUsers();
        Progress GetProgressById(int id);
        Task<Progress> GetProgressByIdAsync(int id);
        Task<Ranks> GetRankByIdAsync(int id);
        Task<RankRequirements> GetRankRequirementsByIdAsync(int id);
        Request GetRequestById(int id);
        Task<Request> GetRequestByIdAsync(int id);
        Task<RequestingGroup> GetRequestingGroupByIdAsync(int id);
        Users GetUserById(int id);
        Task<Users> GetUserByIdAsync(int id);
        IEnumerable<Request> GetAcceptedRequestsByUserId(int id);
        IEnumerable<Request> GetSubmittedRequestsByUserId(int id);
        void Save();
        Task SaveAsync();
        void UpdateAdventurerParty(AdventurerParty adventurerParty);
        Task UpdateAdventurerPartyAsync(AdventurerParty adventurerParty);
        void UpdateProgress(Progress progress);
        Task UpdateProgressAsync(Progress progress);
        void UpdateRank(Ranks Rank);
        Task UpdateRankAsync(Ranks Rank);
        void UpdateRankRequirements(RankRequirements RankRequirements);
        Task UpdateRankRequirementsAsync(RankRequirements RankRequirements);
        void UpdateRequest(Request request);
        Task UpdateRequestAsync(Request request);
        void UpdateRequestingGroup(RequestingGroup RequestingGroup);
        Task UpdateRequestingGroupAsync(RequestingGroup RequestingGroup);
        void UpdateUser(Users user);
        Task UpdateUserAsync(Users user);
    }
}