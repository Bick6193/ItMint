using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using DAL.Attributes;
using DAL.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DAL.Context
{
    public  class AppContext : DbContext
    {
        public AppContext() : base()
        {
             
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
