﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBDv2.Data;

namespace NBDv2.Migrations
{
    [DbContext(typeof(NBDContext))]
    [Migration("20200311163639_h")]
    partial class h
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MC")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NBDv2.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("NBDv2.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<int>("CityID");

                    b.Property<string>("ConFirst")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ConLast")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("ConPhone");

                    b.Property<string>("ConPosition")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("Phone");

                    b.Property<string>("Postal")
                        .HasMaxLength(15);

                    b.Property<string>("Province")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("NBDv2.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeTypeId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NBDv2.Models.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AvgNetPrice");

                    b.Property<double>("ListPrice");

                    b.Property<int>("MaterialID");

                    b.Property<int>("Quantity");

                    b.Property<string>("SizeUnit");

                    b.Property<int>("SizeValue");

                    b.HasKey("ID");

                    b.HasIndex("MaterialID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("NBDv2.Models.Labour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstHours");

                    b.Property<DateTime>("EstStartDate");

                    b.Property<int>("Hours");

                    b.Property<int>("ProjectID");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TaskID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("TaskID");

                    b.ToTable("Labours");
                });

            modelBuilder.Entity("NBDv2.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("NBDv2.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BidCustApproved");

                    b.Property<DateTime>("BidDate");

                    b.Property<bool>("BidManagementApproved");

                    b.Property<int>("ClientID");

                    b.Property<double?>("Cost");

                    b.Property<string>("CurrentPhase");

                    b.Property<string>("Desc")
                        .HasMaxLength(100);

                    b.Property<int>("DesignerID");

                    b.Property<double>("EstCost");

                    b.Property<DateTime>("EstFinishDate");

                    b.Property<DateTime>("EstStartDate");

                    b.Property<DateTime?>("FinishDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DesignerID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NBDv2.Models.ProjectEmployee", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<int>("EmployeeID");

                    b.HasKey("ProjectID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ProjectEmployees");
                });

            modelBuilder.Entity("NBDv2.Models.ProjectMaterials", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<int>("InventoryID");

                    b.Property<int>("MatActQty");

                    b.Property<DateTime>("MatDelivery");

                    b.Property<int>("MatEstQty");

                    b.Property<DateTime>("MatInstall");

                    b.HasKey("ProjectID", "InventoryID");

                    b.HasIndex("InventoryID");

                    b.ToTable("ProjectMaterials");
                });

            modelBuilder.Entity("NBDv2.Models.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc");

                    b.Property<int>("Hours");

                    b.HasKey("ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("NBDv2.Models.Client", b =>
                {
                    b.HasOne("NBDv2.Models.City", "City")
                        .WithMany("Clients")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBDv2.Models.Inventory", b =>
                {
                    b.HasOne("NBDv2.Models.Material", "Material")
                        .WithMany("Inventories")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.Labour", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany("Labour")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NBDv2.Models.Task", "Task")
                        .WithMany("Labours")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBDv2.Models.Project", b =>
                {
                    b.HasOne("NBDv2.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NBDv2.Models.Employee", "Designer")
                        .WithMany("Projects")
                        .HasForeignKey("DesignerID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBDv2.Models.ProjectEmployee", b =>
                {
                    b.HasOne("NBDv2.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.ProjectMaterials", b =>
                {
                    b.HasOne("NBDv2.Models.Inventory", "Inventory")
                        .WithMany("ProjectMaterials")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany("ProjectMaterials")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
