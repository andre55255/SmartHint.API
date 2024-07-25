using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHint.Lib.Models.DbEntities.SmartHintDB
{
    [Table("logs_errors")]
    public class LogErrorSmartHintDbModel : _BaseSmartHintModel
    {
        [Column("message")]
        public string Message { get; set; }
        [Column("place")]
        public string Place { get; set; }
        [Column("exception")]
        public string Exception { get; set; }
        [Column("object")]
        public string Object { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
