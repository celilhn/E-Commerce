using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class LoginLogRepository : ILoginLogRepository
    {
        private readonly ECommerceDbContext context;
        public LoginLogRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public LoginLog AddUserLoginLog(LoginLog userLoginLog)
        {
            context.LoginLogs.Add(userLoginLog);
            context.SaveChanges();
            return userLoginLog;
        }

        public List<LoginLog> GetUserLoginLogs(LoginTypes loginType)
        {
            return context.LoginLogs.Where(x=>x.LoginType == loginType).ToList();
        }
    }
}
