using System.ComponentModel.DataAnnotations;

namespace SmartHint.Lib.Models.Inputs.UsersStores
{
    public class SaveUsersStoresInputVO
    {
        [Required(ErrorMessage = "Não foi informado o nome/razão social, verifique e tente novamente")]
        [StringLength(150, ErrorMessage = "Nome/Razão Social pode ter no máximo 150 caracteres")]
        public string NameOrCorporateReason { get; set; }
        [Required(ErrorMessage = "Não foi informado o email, verifique e tente novamente")]
        [StringLength(150, ErrorMessage = "Email pode ter no máximo 150 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Não foi informado o telefone, verifique e tente novamente")]
        [StringLength(11, ErrorMessage = "Email pode ter no máximo 11 caracteres")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Não foi informado o tipo de pessoa, verifique e tente novamente")]
        public string PersonType { get; set; }
        [Required(ErrorMessage = "Não foi informado o Cpf/Cnpj, verifique e tente novamente")]
        public string CpfCnpj { get; set; }
        public string StateRegistration { get; set; }
        [Required(ErrorMessage = "Não foi informado se o IE é isento, verifique e tente novamente")]
        public bool IsExempt { get; set; }
        public string Gender { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        [Required(ErrorMessage = "Não foi informado se o usuário está bloqueado, verifique e tente novamente")]
        public bool IsBlocked { get; set; }
        public string Password { get; set; }
    }
}
