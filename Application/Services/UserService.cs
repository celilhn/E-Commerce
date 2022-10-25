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
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment environment;
        private readonly IUserLoginLogRepository userLoginLogRepository;
        public UserService(IUserRepository userRepository, IWebHostEnvironment environment, IUserLoginLogRepository userLoginLogRepository)
        {
            this.userRepository = userRepository;
            this.environment = environment;
            this.userLoginLogRepository = userLoginLogRepository;
        }

        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public UserLoginLog SaveUserLoginLog(int userId, LoginStatus loginStatus)
        {
            UserLoginLog userLoginLog = new UserLoginLog();
            userLoginLog.LoginStatus = loginStatus;
            userLoginLog.UserId = userId;
            userLoginLogRepository.AddUserLoginLog(userLoginLog);
            return userLoginLog;
        }

        public User UpdateUser(User user)
        {
            user.UpdateDate = DateTime.Now;
            return userRepository.UpdateUser(user);
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public User GetUser(string email, string password)
        {
            return userRepository.GetUser(email, password);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public List<User> GetUsers(Constants.StatusCodes status)
        {
            return userRepository.GetUsers(status);
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
