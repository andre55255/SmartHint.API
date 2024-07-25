namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class ConflicException : ApplicationException
    {
        public ConflicException(string message, Exception ex = null) : base(message, ex) { }
    }
}
