using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.Enums;

namespace SmartHint.Lib.Repositories.SmartHintDB.Config.Seeds
{
    public class ConfigurationSmartHintDbSeed : IEntityTypeConfiguration<ConfigurationSmartHintDbModel>
    {
        public void Configure(EntityTypeBuilder<ConfigurationSmartHintDbModel> builder)
        {
            builder.HasData(new List<ConfigurationSmartHintDbModel>
            {
                new ConfigurationSmartHintDbModel
                {
                    Id = ConfigurationsEnum.IS_STATE_REGISTRATION_FOR_PF.GetHashCode(),
                    Token = ConfigurationsEnum.IS_STATE_REGISTRATION_FOR_PF.ToString(),
                    Value = "1"
                }
            });
        }
    }
}
