using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL.Context;
using DAL.Models;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("ForceToResetPassword");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsAdministrative");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("DAL.Models.BinaryFileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.HasKey("Id");

                    b.ToTable("BinaryFilesData");
                });

            modelBuilder.Entity("DAL.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BinaryDataId");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("FileIndex");

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<int?>("RequestFormId");

                    b.Property<string>("RequestFormToken");

                    b.Property<int?>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("BinaryDataId")
                        .IsUnique();

                    b.HasIndex("RequestId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DAL.Models.Metadata", b =>
                {
                    b.Property<int>("MetaDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Author");

                    b.Property<string>("Controller");

                    b.Property<string>("Description");

                    b.Property<string>("Keywords");

                    b.Property<string>("Title");

                    b.HasKey("MetaDataId");

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("DAL.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<int?>("RequestTypeId");

                    b.Property<string>("RequestTypeInString")
                        .HasMaxLength(450);

                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<bool>("Viewed");

                    b.HasKey("RequestId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DAL.Models.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeesEmail");

                    b.Property<string>("EmployeesName");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("MessageBodyToCustomer");

                    b.Property<string>("MessageToCustomer");

                    b.Property<int>("OrderWeight");

                    b.Property<bool>("SendEmailToCustomer");

                    b.Property<bool>("SendEmailToEmployee");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("RequestsType");
                });

            modelBuilder.Entity("DAL.Models.File", b =>
                {
                    b.HasOne("DAL.Models.BinaryFileData", "BinaryData")
                        .WithOne("File")
                        .HasForeignKey("DAL.Models.File", "BinaryDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Request", "Request")
                        .WithMany("Files")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("DAL.Models.Request", b =>
                {
                    b.HasOne("DAL.Models.RequestType")
                        .WithMany("RequestForms")
                        .HasForeignKey("RequestTypeId");
                });
        }
    }
}
