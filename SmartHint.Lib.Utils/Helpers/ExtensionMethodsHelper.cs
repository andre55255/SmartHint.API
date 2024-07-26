using SmartHint.Lib.Models.ViewObjects.Utils;
using SmartHint.Lib.Utils.CustomExceptions;
using System.Text;

namespace SmartHint.Lib.Utils.Helpers
{
    public static class ExtensionMethodsHelper
    {
        public static string GetPlace(this object obj)
        {
            return obj.GetType().ToString();
        }

        public static void IsValidId(this int? id)
        {
            if (id == null)
                throw new ServiceException($"Id não informado");

            if (id.Value <= 0)
                throw new ServiceException($"ID informado inválido");
        }

        public static string GetFullTextException(this Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ex.Message);

            if (ex.InnerException != null)
                sb.AppendLine($"InnerException: {GetFullTextException(ex.InnerException)}");

            return sb.ToString();
        }
    }
}
