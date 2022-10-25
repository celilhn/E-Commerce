using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;

namespace Application.Services
{
    public class UserLoginLogService : IUserLoginLogService
    {
        private readonly IUserLoginLogRepository userLoginLogRepository;
        public UserLoginLogService(IUserLoginLogRepository userLoginLogRepository)
        {
            this.userLoginLogRepository = userLoginLogRepository;
        }

        public UserLoginLog AddUserLoginLog(UserLoginLog userLoginLog)
        {
            return userLoginLogRepository.AddUserLoginLog(userLoginLog);
        }

        public List<UserLoginLog> GetUserLoginLogs()
        {
            return userLoginLogRepository.GetUserLoginLogs();
        }
    }
}
