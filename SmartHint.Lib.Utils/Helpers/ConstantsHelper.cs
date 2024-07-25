namespace SmartHint.Lib.Utils.Helpers
{
    public abstract class ConfigAppSettings
    {
        public const string ConnectionStringSmartHintDB = "SmartHint";
        public const string ConfigCors = "ConfigCors";
        public const string VersionApi = "VersionAPI";
    }

    public abstract class ConfigPolicies
    {
        public static string Cors = "ClientPermission";
    }
}
