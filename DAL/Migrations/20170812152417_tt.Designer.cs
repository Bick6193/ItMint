using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL.Context;
using Domain.Authorization;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170812152417_tt")]
    partial class tt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Model.ApiClient", b =>
                {
                    b.Property<string>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("ApplicationType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RefreshTokenLifeTime");

                    b.Property<string>("Secret")
                        .IsRequired();

                    b.HasKey("ClientId");

                    b.ToTable("ApiClients");
                });

            modelBuilder.Entity("DAL.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsOnline");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
