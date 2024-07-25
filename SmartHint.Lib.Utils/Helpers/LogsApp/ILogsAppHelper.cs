using SmartHint.Lib.Models.ViewObjects.Logs;

namespace SmartHint.Lib.Utils.Helpers.LogsApp
{
    public interface ILogsAppHelper
    {
        public void WriteError(LogErrorVO logError);
    }
}
