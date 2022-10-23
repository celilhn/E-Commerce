using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public User UpdateUser(User user)
        {
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

        public List<User> GetUsers(StatusCodes status)
        {
            return userRepository.GetUsers(status);
        }
    }
}
