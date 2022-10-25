using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IAdminUserRepository
    {
        AdminUser AddAdminUser(AdminUser adminUser);
        AdminUser UpdateAdminUser(AdminUser adminUser);
        AdminUser GetAdminUser(int id);
        AdminUser GetAdminUser(string email, string password);
        List<AdminUser> GetAdminUsers();
        List<AdminUser> GetAdminUsers(StatusCodes status);
    }
}
