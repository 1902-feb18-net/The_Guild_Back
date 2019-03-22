using System.Collections.Generic;

namespace The_Guild_Back.BLL
{
    public interface IRepository
    {
        int AddUser(Users users);
        void DeleteUser(int Id);
        int AddLoginInfo(LoginInfo loginInfo);

        IEnumerable<Users> GetAllUsers();
        IEnumerable<LoginInfo> GetAllLoginInfo();

        int AddRequest(Request obj);
        IEnumerable<Request> GetAllRequests();
        void DeleteRequest(int Id);

    }




}
