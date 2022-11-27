using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext context;
        public UserRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public User AddUser(User user)
        {
            context.Userss.Add(user);
            context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            context.Update(user);
            context.Entry<User>(user).Property(x => x.Password).IsModified = false;
            context.SaveChanges();
            return user;
        }

        public User GetUser(int id)
        {
            return context.Userss.SingleOrDefault(x => x.Id == id);
        }

        public User GetUser(string email, string password)
        {
            return context.Userss.SingleOrDefault(x => x.Email == email && x.Password == password);
        }

        public List<User> GetUsers()
        {
            return context.Userss.Where(x=>x.Status != StatusCodes.Deleted).ToList();
        }

        public List<User> GetUsers(StatusCodes status)
        {
            return context.Userss.Where(x => x.Status == status).ToList();
        }

        public bool IsUserExistByPhoneNumber(string phoneNumber)
        {
            return context.Userss.Any(x => x.PhoneNumber == phoneNumber && x.Status != StatusCodes.Deleted);
        }

        public bool IsUserExistByEmail(string email)
        {
            return context.Userss.Any(x => x.Email == email && x.Status != StatusCodes.Deleted);
        }

        public bool ControlUserIsExistWithPhoneNumber(int id, string phoneNumber)
        {
            return context.Userss.Any(x => x.Id == id && x.PhoneNumber == phoneNumber && x.Status != StatusCodes.Deleted);
        }

        public bool ControlUserIsExistWithEmail(int id, string email)
        {
            return context.Userss.Any(x => x.Id == id && x.Email == email && x.Status != StatusCodes.Deleted);
        }
    }
}
