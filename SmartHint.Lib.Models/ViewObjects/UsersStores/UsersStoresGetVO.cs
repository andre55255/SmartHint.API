namespace SmartHint.Lib.Models.ViewObjects.UsersStores
{
    public class UsersStoresGetVO
    {
        public int Id { get; set; }
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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
