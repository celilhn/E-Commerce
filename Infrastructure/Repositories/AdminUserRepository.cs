using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly ECommerceDbContext context;
        public AdminUserRepository(ECommerceDbContext context)
        {
            this.context = context;
        }
        
        public AdminUser AddAdminUser(AdminUser adminUser)
        {
            context.AdminUsers.Add(adminUser);
            context.SaveChanges();
            return adminUser;
        }

        public AdminUser UpdateAdminUser(AdminUser adminUser)
        {
            context.Update(adminUser);
            context.Entry<AdminUser>(adminUser).Property(x => x.Password).IsModified = false;
            context.SaveChanges();
            return adminUser;
        }

        public AdminUser GetAdminUser(int id)
        {
            return context.AdminUsers.SingleOrDefault(x => x.Id == id);
        }

        public AdminUser GetAdminUser(string email, string password)
        {
            return context.AdminUsers.SingleOrDefault(x => x.Email == email && x.Password == password && x.Status != StatusCodes.Deleted);
        }

        public List<AdminUser> GetAdminUsers()
        {
            return context.AdminUsers.Where(x=>x.Status != StatusCodes.Deleted).ToList();
        }

        public List<AdminUser> GetAdminUsers(StatusCodes status)
        {
            return context.AdminUsers.Where(x => x.Status == status).ToList();
        }
    }
}
