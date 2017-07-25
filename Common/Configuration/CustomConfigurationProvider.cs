using System;
using CreditorGuard.Common.Configuration;
using Microsoft.Extensions.Configuration;


namespace Common.Configuration
{
    public class CustomConfigurationProvider : AbstractConfigurationProvider, ICustomConfigurationProvider
    {
        public static readonly ICustomConfigurationProvider DefaultProvider = new DefaultBaseConfigurationProvider();
        
        private IConfigurationRoot Configuration { get; }

        private IConfiguration AppSettings => Configuration.GetSection("AppSettings");

        public CustomConfigurationProvider(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public SeedType SeedType => AppSettings.GetSeedType();
        
        public bool EnableSqlLog => AppSettings.GetBoolean(nameof(EnableSqlLog));

        public bool EnableDetailedSqlLog => AppSettings.GetBoolean(nameof(EnableDetailedSqlLog));
        
        public bool ClientVersionFilterEnabled => AppSettings.GetBoolean(nameof(ClientVersionFilterEnabled));
        
        public string ApplicationUrl => AppSettings.GetString(nameof(ApplicationUrl), true, "http://tfs.itmint.ca/creditorguard/");

        public string Revision => ApplicationVersion.Revision;
        
        public long BuildNumber => ApplicationVersion.BuildNumber;

        public string LoggerSeqUrl => AppSettings.GetString(nameof(LoggerSeqUrl));

        public string LoggerDirectory => AppSettings.GetString(nameof(LoggerDirectory), false, ""); //todo add default path

        public string LoggerConsoleTemplate => AppSettings.GetString(nameof(LoggerConsoleTemplate), true);

        public string LoggerFileTemplate => AppSettings.GetString(nameof(LoggerFileTemplate), true);
        
        public TimeZoneInfo TimeZone => TimeZoneInfo.FindSystemTimeZoneById(AppSettings.GetString(nameof(TimeZone), true));

        public int SMTPSendAttemptsNumber => AppSettings.GetInt(nameof(SMTPSendAttemptsNumber), true);

        public int SMTPSendTimeout => AppSettings.GetInt(nameof(SMTPSendTimeout), true);
        
        public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");
        

        private class DefaultBaseConfigurationProvider:AbstractConfigurationProvider, ICustomConfigurationProvider
        {
            public SeedType SeedType => SeedType.TestData;

            public bool EnableSqlLog => false;

            public bool EnableDetailedSqlLog => false;
            
            public bool ClientVersionFilterEnabled => false;
            
            public string ApplicationUrl => null;

            public string Revision => ApplicationVersion.Revision;
        
            public long BuildNumber => ApplicationVersion.BuildNumber;

            public string LoggerSeqUrl => null;

            public string LoggerDirectory => "..\\..\\..\\..\\CreditorGuard.Web\\Logs";

            public string LoggerConsoleTemplate => "{Timestamp:HH:mm:ss} [{Level}] [{ThreadId}] {File} {Line} {Member} {Message}{NewLine}{Exception}";

            public string LoggerFileTemplate => "{Timestamp:HH:mm:ss} [{Level}] [{ThreadId}] [{HttpRequestId}] [{HttpRequestUrl}] {File} {Line} {Member} {Message}{NewLine}{Exception}";

            public string ConnectionString => null;
            
            public int SMTPSendAttemptsNumber { get; }

            public int SMTPSendTimeout { get; }
            
            //see https://msdn.microsoft.com/en-us/library/gg154758.aspx
            public TimeZoneInfo TimeZone => TimeZoneInfo.FindSystemTimeZoneById(DefaultTimeZone);
        }
    }
}