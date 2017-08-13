using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL.Context;
using Domain.Authorization;
using Domain;
using Domain.Permissions;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170813133113_ttttt")]
    partial class ttttt
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

            modelBuilder.Entity("DAL.Model.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("CanEdit");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("ForceToResetPassword");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsAdministrative");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("DAL.Model.ApplicationUserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<long?>("RoleId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationUserRoles");
                });

            modelBuilder.Entity("DAL.Model.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("CanEdit");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsAdministrative");

                    b.Property<bool>("IsBuiltIn");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DAL.Model.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Object");

                    b.Property<byte>("Permission");

                    b.Property<long?>("RoleId");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("DAL.Model.ApplicationUserRole", b =>
                {
                    b.HasOne("DAL.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("DAL.Model.ApplicationUser", "ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Model.RolePermission", b =>
                {
                    b.HasOne("DAL.Model.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");
                });
        }
    }
}
