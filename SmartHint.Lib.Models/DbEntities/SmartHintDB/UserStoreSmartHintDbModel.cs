using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHint.Lib.Models.DbEntities.SmartHintDB
{
    [Table("users_stores")]
    public class UserStoreSmartHintDbModel : _BaseSmartHintModel
    {
        [Column("name_or_corporate_reason")]
        public string NameOrCorporateReason { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("person_type")]
        public string PersonType { get; set; }
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }
        [Column("state_registration")]
        public string StateRegistration { get; set; }
        [Column("is_exempt")]
        public bool IsExempt { get; set; }
        [Column("gender")]
        public string Gender { get; set; } = null;
        [Column("birth_date")]
        public DateTime? BirthDate { get; set; } = null;
        [Column("is_blocked")]
        public bool IsBlocked { get; set; } = false;
        [Column("password_hash")]
        public string PasswordHash { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
