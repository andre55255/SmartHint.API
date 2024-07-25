namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class ForbbidenException : ApplicationException
    {
        public ForbbidenException(string message, Exception ex = null) : base(message, ex) { }
    }
}
