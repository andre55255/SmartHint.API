using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHint.Lib.Models.DbEntities.SmartHintDB
{
    public class _BaseSmartHintModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
