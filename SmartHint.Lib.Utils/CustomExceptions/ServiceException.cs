namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(string message, Exception ex = null) : base(message, ex) { }
    }
}
