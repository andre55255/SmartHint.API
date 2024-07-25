using Microsoft.EntityFrameworkCore;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Repositories.SmartHintDB.Config.Configurations;
using SmartHint.Lib.Repositories.SmartHintDB.Config.Seeds;

namespace SmartHint.Lib.Repositories.SmartHintDB.Config.Context
{
    public class SmartHintDbContext : DbContext
    {
        public DbSet<ConfigurationSmartHintDbModel> Configurations { get; set; }
        public DbSet<LogErrorSmartHintDbModel> LogErrors { get; set; }
        public DbSet<UserStoreSmartHintDbModel> UsersStores { get; set; }

        public SmartHintDbContext(DbContextOptions<SmartHintDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeds
            modelBuilder.ApplyConfiguration(new ConfigurationSmartHintDbSeed());

            // Configs Entities
            modelBuilder.ApplyConfiguration(new ConfigurationSmartHintDbModelConfiguration())
                        .ApplyConfiguration(new LogErrorSmartHintDbModelConfiguration())
                        .ApplyConfiguration(new UserStoreSmartHintDbModelConfiguration());
        }
    }
}
