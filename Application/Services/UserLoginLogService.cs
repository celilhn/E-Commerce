using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class UserLoginLogService : IUserLoginLogService
    {
        private readonly IUserLoginLogRepository userLoginLogRepository;
        public UserLoginLogService(IUserLoginLogRepository userLoginLogRepository)
        {
            this.userLoginLogRepository = userLoginLogRepository;
        }

        public LoginLog AddUserLoginLog(LoginLog userLoginLog)
        {
            return userLoginLogRepository.AddUserLoginLog(userLoginLog);
        }

        public List<LoginLog> GetUserLoginLogs(LoginTypes loginType)
        {
            return userLoginLogRepository.GetUserLoginLogs(loginType);
        }
    }
}
