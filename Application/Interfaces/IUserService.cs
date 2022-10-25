using System.Collections.Generic;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User AddUser(User user);  
        User UpdateUser(User user);
        User GetUser(int id);
        User GetUser(string email, string password);
        List<User> GetUsers();
        List<User> GetUsers(Constants.StatusCodes status);
        string UploadFile(IFormFile file);
    }
}
