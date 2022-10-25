using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IUserLoginLogRepository
    {
        LoginLog AddUserLoginLog(LoginLog userLoginLog);
        List<LoginLog> GetUserLoginLogs(LoginTypes loginType);
    }
}
