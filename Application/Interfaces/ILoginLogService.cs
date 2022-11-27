using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface ILoginLogService
    {
        LoginLog AddUserLoginLog(LoginLog userLoginLog);
        List<LoginLog> GetUserLoginLogs(LoginTypes loginType);
    }
}
