using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.API.Models;
using The_Guild_Back.BLL;

namespace The_Guild_Back.Api.Models
{
    public class ApiMapper : IApiMapper
    {
        public ApiAdventureParty Map(AdventurerParty adventurerParty) => new ApiAdventureParty
        {
            Name = adventurerParty.Nam,
            Id = adventurerParty.Id,
            AdventurerId = adventurerParty.AdventurerId,
            RequestId = adventurerParty.RequestId
        };

        public AdventurerParty Map(ApiAdventureParty ApiAdventureParty) => new AdventurerParty
        {
            Nam = ApiAdventureParty.Name,
            Id = ApiAdventureParty.Id,
            AdventurerId = ApiAdventureParty.AdventurerId,
            RequestId = ApiAdventureParty.RequestId
        };

        public ApiProgress Map(Progress progress) => new ApiProgress
        {
            Id = progress.Id,
            Nam = progress.Nam
        };

        public Progress Map(ApiProgress ApiProgress) => new Progress
        {
            Id = ApiProgress.Id,
            Nam = ApiProgress.Nam
        };

        public ApiRankRequirements Map(RankRequirements rankRequirements) => new ApiRankRequirements
        {
            Id = rankRequirements.Id,
            CurrentRankId = rankRequirements.CurrentRankId,
            NextRankId = rankRequirements.NextRankId,
            NumberRequests = rankRequirements.NumberRequests,
            MinTotalStats = rankRequirements.MinTotalStats
        };

        public RankRequirements Map(ApiRankRequirements ApiRankRequirements) => new RankRequirements
        {
            Id = ApiRankRequirements.Id,
            CurrentRankId = ApiRankRequirements.CurrentRankId,
            NextRankId = ApiRankRequirements.NextRankId,
            NumberRequests = ApiRankRequirements.NumberRequests,
            MinTotalStats = ApiRankRequirements.MinTotalStats
        };

        public ApiRanks Map(Ranks ranks) => new ApiRanks
        {
            Id = ranks.Id,
            Name = ranks.Nam,
            Fee = ranks.Fee
        };

        public Ranks Map(ApiRanks ApiRanks) => new Ranks
        {
            Id = ApiRanks.Id,
            Nam = ApiRanks.Name,
            Fee = ApiRanks.Fee
        };

        public ApiRequest Map(Request request) => new ApiRequest
        {
            Id = request.Id,
            RankId = request.RankId,
            Descript = request.Descript,
            Requirements = request.Requirements,
            Reward = request.Reward,
            Cost = request.Cost,
            ProgressId = request.ProgressId
        };

        public Request Map(ApiRequest ApiRequest) => new Request
        {
            Id = ApiRequest.Id,
            RankId = ApiRequest.RankId,
            Descript = ApiRequest.Descript,
            Requirements = ApiRequest.Requirements,
            Reward = ApiRequest.Reward,
            Cost = ApiRequest.Cost,
            ProgressId = ApiRequest.ProgressId
        };

        public ApiRequestingParty Map(RequestingGroup requestingGroup) => new ApiRequestingParty
        {
            Id = requestingGroup.Id,
            RequestId = requestingGroup.RequestId,
            CustomerId = requestingGroup.CustomerId
        };

        public RequestingGroup Map(ApiRequestingParty ApiRequestingParty) => new RequestingGroup
        {
            Id = ApiRequestingParty.Id,
            RequestId = ApiRequestingParty.RequestId,
            CustomerId = ApiRequestingParty.CustomerId
        };

        public ApiUsers Map(Users users) => new ApiUsers
        {
            Id = users.Id,
            FirstName = users.FirstName,
            LastName = users.LastName,
            Salary = users.Salary,
            Strength = users.Strength,
            Dex = users.Dex,
            Wisdom = users.Wisdom,
            Intelligence = users.Intelligence,
            Charisma = users.Charisma,
            Constitution = users.Constitution,
            RankId = users.RankId,
        };

        public Users Map(ApiUsers ApiUsers) => new Users
        {
            Id = ApiUsers.Id,
            FirstName = ApiUsers.FirstName,
            LastName = ApiUsers.LastName,
            Salary = ApiUsers.Salary,
            Strength = ApiUsers.Strength,
            Dex = ApiUsers.Dex,
            Wisdom = ApiUsers.Wisdom,
            Intelligence = ApiUsers.Intelligence,
            Charisma = ApiUsers.Charisma,
            Constitution = ApiUsers.Constitution,
            RankId = ApiUsers.RankId,
        };

    }
}
