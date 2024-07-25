namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message, Exception ex = null) : base(message, ex) { }
    }
}
