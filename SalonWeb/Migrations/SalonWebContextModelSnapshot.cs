// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalonWeb.Data;

namespace SalonWeb.Migrations
{
    [DbContext(typeof(SalonWebContext))]
    partial class SalonWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalonWeb.Models.Frizer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FrizerNume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Frizer");
                });

            modelBuilder.Entity("SalonWeb.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrizerID")
                        .HasColumnType("int");

                    b.Property<string>("Notite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ziua")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("FrizerID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("SalonWeb.Models.ProgramareTip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProgramareID")
                        .HasColumnType("int");

                    b.Property<int>("TipID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramareID");

                    b.HasIndex("TipID");

                    b.ToTable("ProgramareTip");
                });

            modelBuilder.Entity("SalonWeb.Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipTuns")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("SalonWeb.Models.Programare", b =>
                {
                    b.HasOne("SalonWeb.Models.Frizer", "Frizer")
                        .WithMany("Programari")
                        .HasForeignKey("FrizerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frizer");
                });

            modelBuilder.Entity("SalonWeb.Models.ProgramareTip", b =>
                {
                    b.HasOne("SalonWeb.Models.Programare", "Programare")
                        .WithMany("ProgramareTips")
                        .HasForeignKey("ProgramareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalonWeb.Models.Tip", "Tip")
                        .WithMany("ProgramareTips")
                        .HasForeignKey("TipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programare");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("SalonWeb.Models.Frizer", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("SalonWeb.Models.Programare", b =>
                {
                    b.Navigation("ProgramareTips");
                });

            modelBuilder.Entity("SalonWeb.Models.Tip", b =>
                {
                    b.Navigation("ProgramareTips");
                });
#pragma warning restore 612, 618
        }
    }
}
