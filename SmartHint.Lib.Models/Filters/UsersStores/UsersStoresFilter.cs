namespace SmartHint.Lib.Models.Filters.UsersStores
{
    public class UsersStoresFilter
    {
        public string NameOrCorporateReason { get; set; } = null;
        public string Email { get; set; } = null;
        public string PhoneNumber { get; set; } = null;
        public string PersonType { get; set; } = null;
        public string CpfCnpj { get; set; } = null;
        public string StateRegistration { get; set; } = null;
        public bool? IsBlocked { get; set; } = null;
    }
}
