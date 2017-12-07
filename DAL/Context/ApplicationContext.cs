using System;
using System.Data;
using DAL.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
  [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
  public class ApplicationContext : DbContext
  {
    static ApplicationContext()
    {

    }
    public ApplicationContext(DbContextOptions<ApplicationContext> connectionString) : base(connectionString)
    {

    }

    
    public DbSet<BinaryFileData> BinaryFilesData { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Metadata> Metadata { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestType> RequestsType { get; set; }
    public DbSet<Projects> Projectses { get; set; }
    public DbSet<ProjectFile> ProjectFiles { get; set; }
    public DbSet<BinaryProjectFileData> BinaryProjectFileDatas { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<ApiUser> ApiUsers { get; set; }
    public DbSet<AppUser> ApplicationUsers { get; set; }



    private bool _transactionInProgress = false;

    public void DoInTransaction([NotNull] Action action, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
    {
      if (_transactionInProgress)
      {
        action.Invoke();
      }
      else
      {
        _transactionInProgress = true;
        try
        {
          using (var transaction = Database.BeginTransaction(isolationLevel))
          {
            action.Invoke();

            transaction.Commit();
          }
        }
        finally
        {
          _transactionInProgress = false;
        }
      }
    }

    public T DoInTransaction<T>([NotNull] Func<T> action, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
    {
      T result;

      if (_transactionInProgress)
      {
        result = action.Invoke();
      }
      else
      {
        _transactionInProgress = true;
        try
        {
          using (var transaction = Database.BeginTransaction(isolationLevel))
          {
            result = action.Invoke();

            transaction.Commit();
          }
        }
        finally
        {
          _transactionInProgress = false;
        }
      }

      return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
    }
  }
}
