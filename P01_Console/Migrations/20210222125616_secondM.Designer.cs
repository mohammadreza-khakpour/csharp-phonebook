﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P01_Console;

namespace P01_Console.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210222125616_secondM")]
    partial class secondM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P01_Console.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumberCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Number");
                });

            modelBuilder.Entity("P01_Console.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersonIsFemale")
                        .HasColumnType("bit");

                    b.Property<string>("PersonLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonPhonebookId")
                        .HasColumnType("int");

                    b.Property<string>("PersonWebsiteAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonPhonebookId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("P01_Console.PhoneBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("PhoneBooks");
                });

            modelBuilder.Entity("P01_Console.Number", b =>
                {
                    b.HasOne("P01_Console.Person", "NumberPerson")
                        .WithMany("PersonNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NumberPerson");
                });

            modelBuilder.Entity("P01_Console.Person", b =>
                {
                    b.HasOne("P01_Console.PhoneBook", "PersonPhonebook")
                        .WithMany("PeopleList")
                        .HasForeignKey("PersonPhonebookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonPhonebook");
                });

            modelBuilder.Entity("P01_Console.Person", b =>
                {
                    b.Navigation("PersonNumbers");
                });

            modelBuilder.Entity("P01_Console.PhoneBook", b =>
                {
                    b.Navigation("PeopleList");
                });
#pragma warning restore 612, 618
        }
    }
}
