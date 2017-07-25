using System;
using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    internal static class ConfigurationExtesions
    {
        public static string GetString(this IConfiguration AppSettings, string name, bool isRequired = false, string defaultValue = null)
        {
            var isEmpty = string.IsNullOrEmpty(AppSettings[name]);

            if (isRequired && isEmpty && string.IsNullOrEmpty(defaultValue))
            {
                throw new Exception($"Required string option is missing: ${name}");
            }

            return isEmpty ? defaultValue : AppSettings[name];
        }

        public static bool GetBoolean(this IConfiguration AppSettings, string name, bool isRequired = false, bool defaultValue = false)
        {
            var isEmpty = string.IsNullOrEmpty(AppSettings[name]);

            if (isRequired && isEmpty)
            {
                throw new Exception($"Required boolean option is missing: ${name}");
            }

            return isEmpty ? defaultValue : AppSettings[name].ToLower() == "true";
        }

        public static int GetInt(this IConfiguration AppSettings, string name, bool isRequired = false, int defaultValue = 0)
        {
            var isEmpty = string.IsNullOrEmpty(AppSettings[name]);

            if (isRequired && isEmpty)
            {
                throw new Exception($"Required int option is missing: ${name}");
            }

            int value;
            if (!int.TryParse(AppSettings[name], out value))
            {
                throw new ArgumentException($"Value of parameter {name} is incorrect");
            }

            return isEmpty ? defaultValue : value;
        }
        public static SeedType GetSeedType(this IConfiguration AppSettings)
        {
            var typeString = AppSettings["SeedType"];

            if (string.IsNullOrWhiteSpace(typeString))
            {
                return SeedType.Non;
            }

            SeedType type;

            if (Enum.TryParse(typeString, true, out type))
            {
                return type;
            }

            throw new ArgumentException($"Value of parameter SeedType is incorrect: {typeString}");
        }
    }
}
