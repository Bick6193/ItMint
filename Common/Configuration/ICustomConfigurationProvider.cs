using System;

namespace Common.Configuration
{

  public interface ICustomConfigurationProvider : IBaseConfigurationProvider
  {

  }


  public interface IBaseConfigurationProvider
  {
    bool EnableSqlLog { get; }

    bool EnableDetailedSqlLog { get; }

    string ApplicationUrl { get; }

    /// <summary>
    /// Git commit hash.
    /// </summary>
    string Revision { get; }

    /// <summary>
    /// Build Number.
    /// </summary>
    long BuildNumber { get; }

    /// <summary>
    /// Enable client version validation filter.
    /// </summary>
    bool ClientVersionFilterEnabled { get; }

    string LoggerSeqUrl { get; }

    string LoggerDirectory { get; }

    string LoggerConsoleTemplate { get; }

    string LoggerFileTemplate { get; }

    string ConnectionString { get; }

    int SMTPSendAttemptsNumber { get; }

    int SMTPSendTimeout { get; }

    TimeZoneInfo TimeZone { get; }

    string ContentRootPath { get; }
  }

  public enum SeedType
  {
    Non,
    TestData,
    StressTestData
  }
}