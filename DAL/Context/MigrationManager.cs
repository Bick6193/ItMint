using System.Linq;
using Common.Configuration;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Common;

namespace DAL.Seed
{
  public class MigrationManager
  {
    private ApplicationContext Context { get; }

    public MigrationManager(ApplicationContext context)
    {
      Context = context;
    }

    public void ApplyMigrations(ICustomConfigurationProvider config)
    {
      Log.Logger().Information("Migration Manager is strating ....");

      var migrations = Context.Database.GetPendingMigrations().ToList();

      if (migrations.Any())
      {
        Log.Logger().Information("Found {number} pending migrations", migrations.Count);
        migrations.ForEach(m => Log.Logger().Information("{name}", m));

        if (config.ApplyMigrations)
        {
          Log.Logger().Information("Migration is enbled");
          Context.Database.Migrate();
          Log.Logger().Information("Migration is applied ");
        }
        else
        {
          Log.Logger().Information("Migration is disabled ");
        }
      }
      else
      {
        Log.Logger().Information("No migrations Found", migrations.Count);
      }
    }
  }
}
