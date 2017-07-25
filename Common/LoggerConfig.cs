//using System.IO;
//using System.Threading;
//using Common.Configuration;
//using Microsoft.Extensions.Configuration;
//using Serilog;
//using Serilog.Core;
//using Serilog.Events;
//using System.Web;

//namespace Common
//{
//    public class LoggerConfig
//    {
//        public static void Configure(ICustomConfigurationProvider configurationProvider)
//        {
//            InitLogger(configurationProvider);
//        }

//        private static void InitLogger(ICustomConfigurationProvider configurationProvider)
//        {
//            var baseDir = configurationProvider.LoggerDirectory;

//            if (string.IsNullOrEmpty(baseDir))
//            {
//                baseDir = Path.Combine(HttpRuntime.AppDomainAppPath, "Logs");
//            }

//            var logFilePath = Path.Combine(baseDir, "log.txt");

//            ApplicationLifecycleModule.RequestLoggingLevel = LogEventLevel.Verbose;

//            var configuration = new LoggerConfiguration()
//                .Enrich.With<ThreadIdEnricher>()
//                .Enrich.With<HttpRequestIdEnricher>()
//                .Enrich.With<HttpRequestUrlEnricher>()
//                .Enrich.With<HttpRequestUserAgentEnricher>()
//                .Enrich.With<UserNameEnricher>()
//                .MinimumLevel.Debug()
//                //.WriteTo.Async(a => a.MSSqlServer(configurationProvider.ConnectionString, "Serilog", restrictedToMinimumLevel:LogEventLevel.Debug, autoCreateSqlTable:true))
//                .WriteTo.Async(a => a.RollingFile(logFilePath, LogEventLevel.Debug, configurationProvider.LoggerFileTemplate, null, 1073741824, 31, null, false, true));

//            if (configurationProvider.IsExpress)
//            {
//                configuration = configuration.WriteTo.LiterateConsole(LogEventLevel.Verbose, configurationProvider.LoggerConsoleTemplate);
//            }

//            var seqServerPath = configurationProvider.LoggerSeqUrl;
//            if (!string.IsNullOrEmpty(seqServerPath))
//            {
//                configuration = configuration.WriteTo.Async(a => a.Seq(seqServerPath));
//            }

//            var logger = configuration.CreateLogger();
//            Serilog.Log.Logger = logger;
            
//            CreditorGuard.Common.Log.Instance = logger;
//        }

//        internal sealed class ThreadIdEnricher : ILogEventEnricher
//        {
//            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
//            {
//                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Thread.CurrentThread.ManagedThreadId));
//            }
//        }
//    }
//}