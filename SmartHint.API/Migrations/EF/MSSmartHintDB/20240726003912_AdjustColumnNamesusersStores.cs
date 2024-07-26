using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHint.API.Migrations.EF.MSSmartHintDB
{
    /// <inheritdoc />
    public partial class AdjustColumnNamesusersStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "users_stores",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users_stores",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "StateRegistration",
                table: "users_stores",
                newName: "state_registration");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users_stores",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PersonType",
                table: "users_stores",
                newName: "person_type");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users_stores",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NameOrCorporateReason",
                table: "users_stores",
                newName: "name_or_corporate_reason");

            migrationBuilder.RenameColumn(
                name: "IsExempt",
                table: "users_stores",
                newName: "is_exempt");

            migrationBuilder.RenameColumn(
                name: "IsBlocked",
                table: "users_stores",
                newName: "is_blocked");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users_stores",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CpfCnpj",
                table: "users_stores",
                newName: "cpf_cnpj");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "users_stores",
                newName: "birth_date");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_Email",
                table: "users_stores",
                newName: "IX_users_stores_email");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_StateRegistration",
                table: "users_stores",
                newName: "IX_users_stores_state_registration");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_CpfCnpj",
                table: "users_stores",
                newName: "IX_users_stores_cpf_cnpj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "users_stores",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users_stores",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "state_registration",
                table: "users_stores",
                newName: "StateRegistration");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "users_stores",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "person_type",
                table: "users_stores",
                newName: "PersonType");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users_stores",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "name_or_corporate_reason",
                table: "users_stores",
                newName: "NameOrCorporateReason");

            migrationBuilder.RenameColumn(
                name: "is_exempt",
                table: "users_stores",
                newName: "IsExempt");

            migrationBuilder.RenameColumn(
                name: "is_blocked",
                table: "users_stores",
                newName: "IsBlocked");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users_stores",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "cpf_cnpj",
                table: "users_stores",
                newName: "CpfCnpj");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "users_stores",
                newName: "BirthDate");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_email",
                table: "users_stores",
                newName: "IX_users_stores_Email");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_state_registration",
                table: "users_stores",
                newName: "IX_users_stores_StateRegistration");

            migrationBuilder.RenameIndex(
                name: "IX_users_stores_cpf_cnpj",
                table: "users_stores",
                newName: "IX_users_stores_CpfCnpj");
        }
    }
}
