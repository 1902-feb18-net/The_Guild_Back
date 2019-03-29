using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public interface IApiMapper
    {
        ApiAdventureParty Map(AdventurerParty adventurerParty);
        AdventurerParty Map(ApiAdventureParty apiAdventureParty);

        ApiProgress Map(Progress progress);
        Progress Map(ApiProgress apiProgress);

        ApiRankRequirements Map(RankRequirements rankRequirements);
        RankRequirements Map(ApiRankRequirements apiRankRequirements);

        ApiRanks Map(Ranks ranks);
        Ranks Map(ApiRanks apiRanks);

        ApiRequest Map(Request request);
        Request Map(ApiRequest apiRequest);

        ApiRequestingParty Map(RequestingGroup requestingGroup);
        RequestingGroup Map(ApiRequestingParty apiRequestingParty);

        ApiUsers Map(Users users);
        Users Map(ApiUsers apiUsers);
    }
}
