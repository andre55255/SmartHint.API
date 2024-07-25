using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;

namespace SmartHint.Lib.Repositories.SmartHintDB.Config.Configurations
{
    public class UserStoreSmartHintDbModelConfiguration : IEntityTypeConfiguration<UserStoreSmartHintDbModel>
    {
        public void Configure(EntityTypeBuilder<UserStoreSmartHintDbModel> builder)
        {
            builder.Property(x => x.NameOrCorporateReason).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.PersonType).IsRequired();
            builder.Property(x => x.CpfCnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.StateRegistration).IsRequired(false).HasMaxLength(12);
            builder.Property(x => x.IsExempt).IsRequired();
            builder.Property(x => x.Gender).IsRequired(false).HasMaxLength(3);
            builder.Property(x => x.BirthDate).IsRequired(false);
            builder.Property(x => x.IsBlocked).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(4096);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.CpfCnpj).IsUnique();
            builder.HasIndex(x => x.StateRegistration).IsUnique();
        }
    }
}
