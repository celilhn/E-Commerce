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
            return context.Userss.ToList();
        }

        public List<User> GetUsers(StatusCodes status)
        {
            return context.Userss.Where(x => x.Status == status).ToList();
        }
    }
}
