using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public class APIMapper : IAPIMapper
    {
        public APIAdventureParty Map(AdventurerParty adventurerParty) => new APIAdventureParty
        {
            Name = adventurerParty.Nam,
            Id = adventurerParty.Id,
            AdventurerId = adventurerParty.AdventurerId,
            RequestId = adventurerParty.RequestId
        };

        public AdventurerParty Map(APIAdventureParty apiAdventureParty) => new AdventurerParty
        {
            Nam = apiAdventureParty.Name,
            Id = apiAdventureParty.Id,
            AdventurerId = apiAdventureParty.AdventurerId,
            RequestId = apiAdventureParty.RequestId
        };

        public APIProgress Map(Progress progress) => new APIProgress
        {
            Id = progress.Id,
            Nam = progress.Nam
        };

        public Progress Map(APIProgress apiProgress) => new Progress
        {
            Id = apiProgress.Id,
            Nam = apiProgress.Nam
        };

        public APIRankRequirements Map(RankRequirements rankRequirements) => new APIRankRequirements
        {
            Id = rankRequirements.Id,
            CurrentRankId = rankRequirements.CurrentRankId,
            NextRankId = rankRequirements.NextRankId,
            NumberRequests = rankRequirements.NumberRequests,
            MinTotalStats = rankRequirements.MinTotalStats
        };

        public RankRequirements Map(APIRankRequirements apiRankRequirements) => new RankRequirements
        {
            Id = apiRankRequirements.Id,
            CurrentRankId = apiRankRequirements.CurrentRankId,
            NextRankId = apiRankRequirements.NextRankId,
            NumberRequests = apiRankRequirements.NumberRequests,
            MinTotalStats = apiRankRequirements.MinTotalStats
        };

        public APIRanks Map(Ranks ranks) => new APIRanks
        {
            Id = ranks.Id,
            Name = ranks.Nam,
            Fee = ranks.Fee
        };

        public Ranks Map(APIRanks apiRanks) => new Ranks
        {
            Id = apiRanks.Id,
            Nam = apiRanks.Name,
            Fee = apiRanks.Fee
        };

        public APIRequest Map(Request request) => new APIRequest
        {
            Id = request.Id,
            RankId = request.RankId,
            Descript = request.Descript,
            Requirements = request.Requirements,
            Reward = request.Reward,
            Cost = request.Cost,
            ProgressId = request.ProgressId
        };

        public Request Map(APIRequest apiRequest) => new Request
        {
            Id = apiRequest.Id,
            RankId = apiRequest.RankId,
            Descript = apiRequest.Descript,
            Requirements = apiRequest.Requirements,
            Reward = apiRequest.Reward,
            Cost = apiRequest.Cost,
            ProgressId = apiRequest.ProgressId
        };

        public APIRequestingParty Map(RequestingGroup requestingGroup) => new APIRequestingParty
        {
            Id = requestingGroup.Id,
            RequestId = requestingGroup.RequestId,
            CustomerId = requestingGroup.CustomerId
        };

        public RequestingGroup Map(APIRequestingParty apiRequestingParty) => new RequestingGroup
        {
            Id = apiRequestingParty.Id,
            RequestId = apiRequestingParty.RequestId,
            CustomerId = apiRequestingParty.CustomerId
        };

        public APIUsers Map(Users users) => new APIUsers
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

        public Users Map(APIUsers apiUsers) => new Users
        {
            Id = apiUsers.Id,
            FirstName = apiUsers.FirstName,
            LastName = apiUsers.LastName,
            Salary = apiUsers.Salary,
            Strength = apiUsers.Strength,
            Dex = apiUsers.Dex,
            Wisdom = apiUsers.Wisdom,
            Intelligence = apiUsers.Intelligence,
            Charisma = apiUsers.Charisma,
            Constitution = apiUsers.Constitution,
            RankId = apiUsers.RankId,
        };

    }
}
