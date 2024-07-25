using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHint.Lib.Models.DbEntities.SmartHintDB
{
    [Table("users_stores")]
    public class UserStoreSmartHintDbModel : _BaseSmartHintModel
    {
        public string NameOrCorporateReason { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonType { get; set; }
        public string CpfCnpj { get; set; }
        public string StateRegistration { get; set; }
        public bool IsExempt { get; set; }
        public string Gender { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public bool IsBlocked { get; set; } = false;
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
