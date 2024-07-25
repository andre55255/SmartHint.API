using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;

namespace SmartHint.Lib.Repositories.SmartHintDB.Config.Configurations
{
    public class LogErrorSmartHintDbModelConfiguration : IEntityTypeConfiguration<LogErrorSmartHintDbModel>
    {
        public void Configure(EntityTypeBuilder<LogErrorSmartHintDbModel> builder)
        {
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.Place).IsRequired();
            builder.Property(x => x.Exception).IsRequired(false);
            builder.Property(x => x.Object).IsRequired(false);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        }
    }
}
