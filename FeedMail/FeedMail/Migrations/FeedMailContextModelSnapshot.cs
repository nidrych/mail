﻿// <auto-generated />
using System;
using FeedMail.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedMail.Migrations
{
    [DbContext(typeof(FeedMailContext))]
    partial class FeedMailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FeedMail.EntityFramework.FeedReceiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FeedReceivers");
                });

            modelBuilder.Entity("FeedMail.EntityFramework.Rss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FeedReceiverId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeedReceiverId");

                    b.ToTable("Rss");
                });

            modelBuilder.Entity("FeedMail.EntityFramework.Rss", b =>
                {
                    b.HasOne("FeedMail.EntityFramework.FeedReceiver", null)
                        .WithMany("NewsFeed")
                        .HasForeignKey("FeedReceiverId");
                });

            modelBuilder.Entity("FeedMail.EntityFramework.FeedReceiver", b =>
                {
                    b.Navigation("NewsFeed");
                });
#pragma warning restore 612, 618
        }
    }
}