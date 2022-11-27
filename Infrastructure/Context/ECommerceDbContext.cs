using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) :
            base(options)
        {
            
        }

        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Userss { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Tag> Tagss { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FaqConfigurations());
            modelBuilder.ApplyConfiguration(new BrandConfigurations());
            modelBuilder.ApplyConfiguration(new SizeConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new LoginLogConfigurations());
            modelBuilder.ApplyConfiguration(new AdminUserConfigurations());
            modelBuilder.ApplyConfiguration(new SliderConfigurations());
            modelBuilder.ApplyConfiguration(new TagConfigurations());
            modelBuilder.ApplyConfiguration(new MaterialConfigurations());
            modelBuilder.ApplyConfiguration(new ColorConfigurations());
        }
    }
}
