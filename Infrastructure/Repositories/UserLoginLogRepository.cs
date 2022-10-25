using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserLoginLogRepository : IUserLoginLogRepository
    {
        private readonly ECommerceDbContext context;
        public UserLoginLogRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public UserLoginLog AddUserLoginLog(UserLoginLog userLoginLog)
        {
            context.UserLoginLogs.Add(userLoginLog);
            context.SaveChanges();
            return userLoginLog;
        }

        public List<UserLoginLog> GetUserLoginLogs()
        {
            return context.UserLoginLogs.ToList();
        }
    }
}
