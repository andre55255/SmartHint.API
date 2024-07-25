namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message, Exception ex = null) : base(message, ex) { }
    }
}
