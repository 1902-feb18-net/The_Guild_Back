using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Guild_Back.BLL;

namespace The_Guild_Back.API.Models
{
    public interface IAPIMapper
    {
        APIAdventureParty Map(AdventurerParty adventurerParty);
        AdventurerParty Map(APIAdventureParty apiAdventureParty);

        APIProgress Map(Progress progress);
        Progress Map(APIProgress apiProgress);

        APIRankRequirements Map(RankRequirements rankRequirements);
        RankRequirements Map(APIRankRequirements apiRankRequirements);

        APIRanks Map(Ranks ranks);
        Ranks Map(APIRanks apiRanks);

        APIRequest Map(Request request);
        Request Map(APIRequest apiRequest);

        APIRequestingParty Map(RequestingGroup requestingGroup);
        RequestingGroup Map(APIRequestingParty apiRequestingParty);

        APIUsers Map(Users users);
        Users Map(APIUsers apiUsers);
    }
}
