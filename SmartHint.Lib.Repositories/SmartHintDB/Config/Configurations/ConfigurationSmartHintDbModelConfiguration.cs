using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;

namespace SmartHint.Lib.Repositories.SmartHintDB.Config.Configurations
{
    public class ConfigurationSmartHintDbModelConfiguration : IEntityTypeConfiguration<ConfigurationSmartHintDbModel>
    {
        public void Configure(EntityTypeBuilder<ConfigurationSmartHintDbModel> builder)
        {
            builder.Property(x => x.Token).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(1024).IsRequired();

            builder.HasIndex(x => x.Token).IsUnique();
        }
    }
}
