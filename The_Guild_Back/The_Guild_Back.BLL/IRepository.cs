using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public interface IRepository
    {
        void AddUser(Users users);
        void DeleteUser(int Id);
        void AddLoginInfo(LoginInfo loginInfo);

        IEnumerable<Users> GetAllUsers();
        IEnumerable<LoginInfo> GetAllLoginInfo();

        void AddRequest(Request obj);
        IEnumerable<Request> GetAllRequests();
        void DeleteRequest(int Id);

    }




}
