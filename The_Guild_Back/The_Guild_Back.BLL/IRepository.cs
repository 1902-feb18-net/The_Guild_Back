using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public interface IRepository
    {
        int AddUser(Users users);
        void DeleteUser(int Id);
        Users GetUserById(int id);
        IEnumerable<Users> GetAllUsers();
        void UpdateUser(Users user);

        int AddRequest(Request obj);
        IEnumerable<Request> GetAllRequests();
        void DeleteRequest(int Id);
        Request GetRequestById(int id);
        void UpdateRequest(Request request);


        int AddProgress(Progress progress);
        IEnumerable<Progress> GetAllProgress();
        Progress GetProgressById(int id);
        void UpdateProgress(Progress progress);

        int AddAdventurerParty(AdventurerParty adventurerParty);
        IEnumerable<AdventurerParty> GetAllAdventurerParties();
        AdventurerParty GetAdventurerPartyById(int id);
        void UpdateAdventurerParty(AdventurerParty adventurerParty);

        void Save();

    }




}
