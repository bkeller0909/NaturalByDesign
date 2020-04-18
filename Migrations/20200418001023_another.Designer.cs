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
    [Migration("20200418001023_another")]
    partial class another
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MC")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NBDv2.Models.Bid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("BidID")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<DateTime>("EstEnd");

                    b.Property<DateTime>("EstStart");

                    b.Property<string>("Location");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("NBDv2.Models.BidReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActlCosts");

                    b.Property<int>("ActlHours");

                    b.Property<int>("CostsRemaining");

                    b.Property<int>("EstBid");

                    b.Property<int>("EstCost");

                    b.Property<int>("EstHours");

                    b.Property<int>("HoursRemaining");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("BidReport");
                });

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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeTypeID");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeTypeID");

                    b.HasIndex("TeamID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NBDv2.Models.EmployeeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("HourlyCost");

                    b.Property<double>("HourlyPay");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("EmployeeTypes");
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

            modelBuilder.Entity("NBDv2.Models.InventoryBid", b =>
                {
                    b.Property<int>("BidID");

                    b.Property<int>("ItemID");

                    b.HasKey("BidID", "ItemID");

                    b.ToTable("InvBids");
                });

            modelBuilder.Entity("NBDv2.Models.Labour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstHours");

                    b.Property<DateTime>("EstStartDate");

                    b.Property<int>("Hours");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TaskID");

                    b.Property<int>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("TaskID");

                    b.HasIndex("TeamID");

                    b.ToTable("Labours");
                });

            modelBuilder.Entity("NBDv2.Models.LabourSummary", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<int>("EmployeeTypeID");

                    b.Property<int>("Hours");

                    b.HasKey("ProjectID", "EmployeeTypeID");

                    b.HasIndex("EmployeeTypeID");

                    b.ToTable("LabourSummaries");
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

            modelBuilder.Entity("NBDv2.Models.ProductionReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActualDesignCost");

                    b.Property<int>("ActualLabourProdCost");

                    b.Property<int>("ActualMtlCost");

                    b.Property<int>("BidCost");

                    b.Property<int>("EstCost");

                    b.Property<int>("EstDesignCost");

                    b.Property<int>("EstLabourProdCost");

                    b.Property<int>("EstMtlCost");

                    b.Property<int>("ProjectID");

                    b.Property<int>("TotalCost");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProductionReports");
                });

            modelBuilder.Entity("NBDv2.Models.ProductionWorkReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectID");

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProductionWorkReports");
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
                        .IsRequired()
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

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

                    b.Property<string>("Desc")
                        .IsRequired();

                    b.Property<int>("Hours");

                    b.Property<string>("ResponsibilityType")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("NBDv2.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProductionID");

                    b.Property<int?>("ProjectsID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectsID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NBDv2.Models.Bid", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.BidReport", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.Client", b =>
                {
                    b.HasOne("NBDv2.Models.City", "City")
                        .WithMany("Clients")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBDv2.Models.Employee", b =>
                {
                    b.HasOne("NBDv2.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NBDv2.Models.Team")
                        .WithMany("Employees")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("NBDv2.Models.Inventory", b =>
                {
                    b.HasOne("NBDv2.Models.Material", "Material")
                        .WithMany("Inventories")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.InventoryBid", b =>
                {
                    b.HasOne("NBDv2.Models.Bid", "Bid")
                        .WithMany("InvBids")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.Labour", b =>
                {
                    b.HasOne("NBDv2.Models.Task", "Task")
                        .WithMany("Labours")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NBDv2.Models.ProjectEmployee", "Team")
                        .WithMany("Labours")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBDv2.Models.LabourSummary", b =>
                {
                    b.HasOne("NBDv2.Models.EmployeeType", "EmployeeType")
                        .WithMany("LabourSummaries")
                        .HasForeignKey("EmployeeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany("LabourSummaries")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.ProductionReport", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBDv2.Models.ProductionWorkReport", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .WithMany("ProjectEmployees")
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

            modelBuilder.Entity("NBDv2.Models.Team", b =>
                {
                    b.HasOne("NBDv2.Models.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsID");
                });
#pragma warning restore 612, 618
        }
    }
}
