using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User UpdateUser(User user);
        User GetUser(int id);
        User GetUser(string email, string password);
        List<User> GetUsers();
        List<User> GetUsers(StatusCodes status);
        bool IsUserExistByPhoneNumber(string phoneNumber);
        bool IsUserExistByEmail(string email);
        bool ControlUserIsExistWithPhoneNumber(int id, string phoneNumber);
        bool ControlUserIsExistWithEmail(int id, string email);
    }
}
