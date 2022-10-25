using System.Collections.Generic;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IAdminUserService
    {
        AdminUser AddAdminUser(AdminUser adminUser);
        LoginLog SaveAdminUserLoginLog(string email, string password, LoginStatus loginStatus);
        AdminUser UpdateAdminUser(AdminUser adminUser);
        AdminUser GetAdminUser(int id);
        AdminUser GetAdminUser(string email, string password);
        List<AdminUser> GetAdminUsers();
        List<AdminUser> GetAdminUsers(Constants.StatusCodes status);
        string UploadFile(IFormFile file);
    }
}
