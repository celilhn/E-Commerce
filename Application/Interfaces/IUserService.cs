using System.Collections.Generic;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User AddUser(User user);
        LoginLog SaveUserLoginLog(string email, string password, LoginStatus loginStatus);
        User UpdateUser(User user);
        User GetUser(int id);
        User GetUser(string email, string password);
        List<User> GetUsers();
        List<User> GetUsers(Constants.StatusCodes status);
        string UploadFile(IFormFile file);
    }
}
