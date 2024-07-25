using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHint.Lib.Models.DbEntities.SmartHintDB
{
    [Table("configurations")]
    public class ConfigurationSmartHintDbModel : _BaseSmartHintModel
    {
        [Column("token")]
        public string Token { get; set; }
        [Column("value")]
        public string Value { get; set; }
    }
}
