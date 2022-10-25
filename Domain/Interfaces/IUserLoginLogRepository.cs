using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserLoginLogRepository
    {
        UserLoginLog AddUserLoginLog(UserLoginLog userLoginLog);
        List<UserLoginLog> GetUserLoginLogs();
    }
}
