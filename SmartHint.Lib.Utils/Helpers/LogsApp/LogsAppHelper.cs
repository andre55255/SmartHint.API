using Microsoft.Extensions.Configuration;
using MySqlConnector;
using SmartHint.Lib.Models.ViewObjects.Logs;
using System.Text.Json;

namespace SmartHint.Lib.Utils.Helpers.LogsApp
{
    public class LogsAppHelper : ILogsAppHelper
    {
        private readonly IConfiguration _configuration;

        public LogsAppHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void WriteError(LogErrorVO logError)
        {
            try
            {
                Task.Run(async () => await FireAndForgetLogRegisterAsync(logError));
            }
            catch (Exception) { }
        }

        private async Task FireAndForgetLogRegisterAsync(LogErrorVO logError)
        {
            var connString = GetConnectionString();

            using (var conn = new MySqlConnection(connString))
            {
                try
                {
                    await conn.OpenAsync();

                    var exceptionMessage = logError.Exception != null ? logError.Exception.GetFullTextException() : "";

                    var query =
                        $@"insert into 
                            logs_errors(message, place, exception, object) 
                           values 
                             (@Message, @Place, @Exception, @Object);";

                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Message", logError.Message);
                        command.Parameters.AddWithValue("@Place", logError.Place);
                        command.Parameters.AddWithValue("@Exception", exceptionMessage);
                        command.Parameters.AddWithValue("@Object", SerializeObject(logError.Object));

                        await command.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    await conn.CloseAsync();
                }

            }
        }

        private string SerializeObject(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString(ConfigAppSettings.ConnectionStringSmartHintDB);
        }
    }
}
