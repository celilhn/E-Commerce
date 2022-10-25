using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserLoginLogService
    {
        UserLoginLog AddUserLoginLog(UserLoginLog userLoginLog);
        List<UserLoginLog> GetUserLoginLogs();
    }
}
