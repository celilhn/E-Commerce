using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User AddUser(User user);  
        User UpdateUser(User user);
        User GetUser(int id);
        User GetUser(string email, string password);
        List<User> GetUsers();
        List<User> GetUsers(StatusCodes status);
    }
}
