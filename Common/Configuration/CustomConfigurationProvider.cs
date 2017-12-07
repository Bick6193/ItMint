using System;
using CreditorGuard.Common.Configuration;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;


namespace Common.Configuration
{
  [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
  public class CustomConfigurationProvider : AbstractConfigurationProvider, ICustomConfigurationProvider
  {
    private IConfigurationRoot Configuration { get; }

    private IConfiguration AppSettings => Configuration.GetSection("AppSettings");

    public CustomConfigurationProvider(IConfigurationRoot configuration, string contentRootPath)
    {
      Configuration = configuration;
      ContentRootPath = contentRootPath;
    }

    public SeedType SeedType => AppSettings.GetSeedType();

    public bool ApplyMigrations => AppSettings.GetBoolean(nameof(ApplyMigrations), false, false);

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

    public string ContentRootPath { get; private set; }

    public int SMTPSendAttemptsNumber => AppSettings.GetInt(nameof(SMTPSendAttemptsNumber), true);

    public int SMTPSendTimeout => AppSettings.GetInt(nameof(SMTPSendTimeout), true);

    public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");
  }
}