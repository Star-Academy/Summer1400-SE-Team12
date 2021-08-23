﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQLHandler;

namespace SQLHandler.Migrations
{
    [DbContext(typeof(InvertedIndexContext))]
    [Migration("20210816194537_invertedIndexMigration")]
    partial class invertedIndexMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocumentWord", b =>
                {
                    b.Property<int>("DocsCollectionid")
                        .HasColumnType("int");

                    b.Property<int>("wordsCollectionid")
                        .HasColumnType("int");

                    b.HasKey("DocsCollectionid", "wordsCollectionid");

                    b.HasIndex("wordsCollectionid");

                    b.ToTable("DocumentWord");
                });

            modelBuilder.Entity("SQLHandler.Document", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocContents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DocumentsDbContext");
                });

            modelBuilder.Entity("SQLHandler.Word", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("WordsDbContext");
                });

            modelBuilder.Entity("DocumentWord", b =>
                {
                    b.HasOne("SQLHandler.Document", null)
                        .WithMany()
                        .HasForeignKey("DocsCollectionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SQLHandler.Word", null)
                        .WithMany()
                        .HasForeignKey("wordsCollectionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
