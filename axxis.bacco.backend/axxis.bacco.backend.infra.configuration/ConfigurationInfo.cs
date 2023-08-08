namespace axxis.bacco.backend.infra.configuration
{
    public class ConfigurationInfo
    {
        private static string _Environment;

        public static void SetEnvironmentName(string name)
        {
            _Environment = name;
        }

        public static string GetPort()
        {
            return GetEnvVariable("Port", "13220");
        }

        public static string GetDatabaseType()
        {
            return GetEnvVariable("DatabaseType", "oracle");
        }

        public static string GetDatabaseHost()
        {
            return GetEnvVariable("DatabaseHost", string.Empty);
        }

        public static string GetDatabasePort()
        {
            return GetEnvVariable("DatabasePort", string.Empty);
        }

        public static string GetDatabaseServiceName()
        {
            return GetEnvVariable("DatabaseServiceName", string.Empty);
        }
        public static string GetDatabaseName()
        {
            return GetEnvVariable("DatabaseName", string.Empty);
        }

        public static string GetDatabaseUserId()
        {
            return GetEnvVariable("DatabaseUserId", string.Empty);
        }

        public static string GetDatabasePassword()
        {
            return GetEnvVariable("DatabasePassword", string.Empty);
        }

        public static string GetDatabaseSchema()
        {
            return GetEnvVariable("DatabaseSchema", string.Empty);
        }

        private static string GetEnvVariable(string variableName, string defaultValue)
        {
            if (string.IsNullOrEmpty(_Environment) == false)
            {
                variableName = $"{_Environment}-{variableName}";
            }

            var result = Environment.GetEnvironmentVariable(variableName);
            if (string.IsNullOrEmpty(result) == true)
            {
                result = defaultValue;
            }

            return result;
        }
    }
}