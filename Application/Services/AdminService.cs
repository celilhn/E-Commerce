using System;
using System.Collections.Generic;
using System.IO;
using Application.Interfaces;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class AdminService : IAdminUserService
    {
        private readonly IAdminUserRepository adminUserRepository;
        private readonly IWebHostEnvironment environment;
        private readonly IUserLoginLogRepository userLoginLogRepository;
        public AdminService(IAdminUserRepository adminUserRepository, IWebHostEnvironment environment, IUserLoginLogRepository userLoginLogRepository)
        {
            this.adminUserRepository = adminUserRepository;
            this.environment = environment;
            this.userLoginLogRepository = userLoginLogRepository;
        }
        
        public AdminUser AddAdminUser(AdminUser adminUser)
        {
            return adminUserRepository.AddAdminUser(adminUser);
        }

        public LoginLog SaveAdminUserLoginLog(string email, string password, LoginStatus loginStatus)
        {
            LoginLog userLoginLog = new LoginLog();
            userLoginLog.Email = email;
            userLoginLog.HashPassword = password;
            userLoginLog.LoginStatus = loginStatus;
            userLoginLog.LoginType = LoginTypes.Panel;
            userLoginLogRepository.AddUserLoginLog(userLoginLog);
            return userLoginLog;
        }

        public AdminUser UpdateAdminUser(AdminUser adminUser)
        {
            adminUser.UpdateDate = DateTime.Now;
            return adminUserRepository.UpdateAdminUser(adminUser);
        }

        public AdminUser GetAdminUser(int id)
        {
            return adminUserRepository.GetAdminUser(id);
        }

        public AdminUser GetAdminUser(string email, string password)
        {
            return adminUserRepository.GetAdminUser(email, password);
        }

        public List<AdminUser> GetAdminUsers()
        {
            return adminUserRepository.GetAdminUsers();
        }

        public List<AdminUser> GetAdminUsers(Constants.StatusCodes status)
        {
            return adminUserRepository.GetAdminUsers(status);
        }

        public string UploadFile(IFormFile file)
        {
            string uniqueFileName = "";
            if (file != null)
            {
                uniqueFileName = GetUniqueFileName(file.FileName);
                string contentRootPath = environment.ContentRootPath;
                string webRootPath = environment.WebRootPath;
                webRootPath = webRootPath + "\\images";
                var filePath = Path.Combine(webRootPath, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
}
