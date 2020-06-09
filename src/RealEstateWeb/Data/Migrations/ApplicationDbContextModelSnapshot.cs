﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateWeb.Data;

namespace RealEstateWeb.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.BookmarkedProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PropertyId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.ContactRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Message")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("ContactRequests");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.NearByFacilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodStoreDistance");

                    b.Property<double>("FoodStores");

                    b.Property<int>("HospitalDistance");

                    b.Property<double>("Hospitals");

                    b.Property<double>("School");

                    b.Property<int>("SchoolDistance");

                    b.HasKey("Id");

                    b.ToTable("Facilitieses");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.NewsLetterClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ClientsForNewsLetter");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloudUrl");

                    b.Property<int>("PropertyId");

                    b.Property<string>("PublicId");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("AgentId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<int>("FacilitiesId");

                    b.Property<int>("OwnerId");

                    b.Property<decimal>("Price");

                    b.Property<int>("PropertyDetailsId");

                    b.Property<int>("PropertyPurpose");

                    b.Property<int>("PropertyStatus");

                    b.Property<int>("PropertyStatusId");

                    b.Property<int>("PropertyType");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AgentId");

                    b.HasIndex("FacilitiesId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PropertyDetailsId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.PropertyClient", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<int>("ClientId");

                    b.HasKey("PropertyId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("PropertiesClients");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.PropertyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("HomeArea");

                    b.Property<int?>("NumberOfBathrooms");

                    b.Property<int?>("NumberOfBedrooms");

                    b.Property<int?>("NumberOfBeds");

                    b.Property<double>("TotalArea");

                    b.Property<int?>("YearOfBuild");

                    b.HasKey("Id");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.ViewAppointment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgentId");

                    b.Property<int>("BuyerId");

                    b.Property<DateTime>("DateOfAppointment");

                    b.Property<int>("PropertyId");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.BookmarkedProperty", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Picture", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.Property", "Property")
                        .WithMany("Pictures")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.Property", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser", "Agent")
                        .WithMany("Properties")
                        .HasForeignKey("AgentId");

                    b.HasOne("RealEstateWeb.Models.DbModels.NearByFacilities", "Facilities")
                        .WithMany()
                        .HasForeignKey("FacilitiesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.Client", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.PropertyDetails", "PropertyDetails")
                        .WithMany()
                        .HasForeignKey("PropertyDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.PropertyClient", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateWeb.Models.DbModels.ViewAppointment", b =>
                {
                    b.HasOne("RealEstateWeb.Models.DbModels.ApplicationUser", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId");

                    b.HasOne("RealEstateWeb.Models.DbModels.Client", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateWeb.Models.DbModels.Property", "Property")
                        .WithMany("Views")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
