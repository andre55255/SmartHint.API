namespace SmartHint.Lib.Models.ViewObjects.Logs
{
    public class LogErrorVO
    {
        public string Message { get; set; }
        public string Place { get; set; }
        public Exception Exception { get; set; }
        public object Object { get; set; }
    }
}
