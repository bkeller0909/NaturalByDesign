using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBDv2.Models;

namespace NBDv2.Data
{
    public static class MCSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NBDContext(
                serviceProvider.GetRequiredService<DbContextOptions<NBDContext>>()))
            {
                // Look for any Patients.  Since we can't have patients without Doctors.

                //Add some Medical Trials
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(
                     new City
                     {
                         Name = "Niagara Falls"
                     },
                     new City
                     {
                         Name = "St Catharines"
                     },
                     new City
                     {
                         Name = "NOTL"
                     });
                    context.SaveChanges();
                }

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                    new Client
                    {
                        Name = "Fake Inc",
                        Phone = 9055551234,
                        Address = "Placeholder",
                        Province = "Ontario",
                        Postal = "Placeholder",
                        ConFirst = "Placeholder",
                        ConLast = "Placeholder",
                        ConPhone = 9055551234,
                        ConPosition = "Placeholder",
                        CityID = context.Cities.FirstOrDefault(c => c.Name == "St Catharines").ID
                    },
                    new Client
                    {
                        Name = "Master Contender Enterprise",
                        Phone = 9055551234,
                        Address = "Placeholder",
                        Province = "Ontario",
                        Postal = "Placeholder",
                        ConFirst = "Placeholder",
                        ConLast = "Placeholder",
                        ConPhone = 9055551234,
                        ConPosition = "Placeholder",
                        CityID = context.Cities.FirstOrDefault(c => c.Name == "Niagara Falls").ID
                    },
                    new Client
                    {
                        Name = "Papadimitriou Inc",
                        Phone = 9055551234,
                        Address = "Placeholder",
                        Province = "Ontario",
                        Postal = "Placeholder",
                        ConFirst = "Placeholder",
                        ConLast = "Placeholder",
                        ConPhone = 9055551234,
                        ConPosition = "Placeholder",
                        CityID = context.Cities.FirstOrDefault(c => c.Name == "NOTL").ID
                    },
                    new Client
                    {
                        Name = "LS Mall",
                        Phone = 9055551234,
                        Address = "12638 Mall Dr",
                        Province = "Ontario",
                        Postal = "L2R9N5",
                        ConFirst = "Amy",
                        ConLast = "Benson",
                        ConPhone = 9056879900,
                        ConPosition = "Manager",
                        CityID = context.Cities.FirstOrDefault(c => c.Name == "St Catharines").ID
                    });
                    context.SaveChanges();
                }

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            FirstName = "Cheryl",
                            LastName = "Poy",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Botanist").ID

                        },
                        new Employee
                        {
                            FirstName = "Keri",
                            LastName = "Yamaguchi",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Design Manager").ID
                        },
                        new Employee
                        {
                            FirstName = "Tamara",
                            LastName = "Bakken",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Designer").ID
                        },
                        new Employee
                        {
                            FirstName = "Bob",
                            LastName = "Reinhardt",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Sales Associate").ID
                        },
                        new Employee
                        {
                            FirstName = "Sue",
                            LastName = "Kaufman",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Production Manager").ID
                        },
                        new Employee
                        {
                            FirstName = "Monica",
                            LastName = "Goce",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Production Worker").ID
                        },
                        new Employee
                        {
                            FirstName = "Bert",
                            LastName = "Swenson",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Production Worker").ID
                        },
                        new Employee
                        {
                            FirstName = "Stan",
                            LastName = "Fenton",
                            // EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Sales and Finance Manager").ID
                        },
                        new Employee
                        {
                            FirstName = "Joe",
                            LastName = "Smith",
                            // EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Equipment Operator").ID
                        },
                        new Employee
                        {
                            FirstName = "Jerry",
                            LastName = "Jones",
                            //EmployeeTypeId = context.EmployeeTypes.FirstOrDefault(t => t.Type == "Production Worker").ID
                        });
                    context.SaveChanges();
                }
                /*
                if (!context.EmployeeTypes.Any())
                {
                    context.EmployeeTypes.AddRange(
                        new EmployeeType
                        {
                            Type = "Production Worker",
                            HourlyPay = 18.00,
                            HourlyCharge = 30.00
                        },
                        new EmployeeType
                        {
                            Type = "Designer",
                            HourlyPay = 40.00,
                            HourlyCharge = 65.00
                        },
                        new EmployeeType
                        {
                            Type = "Equipment Operator",
                            HourlyPay = 45.00,
                            HourlyCharge = 65.00
                        },
                        new EmployeeType
                        {
                            Type = "Botanist",
                            HourlyPay = 50.00,
                            HourlyCharge = 75.00
                        },
                        new EmployeeType
                        {
                            Type = "Design Manager",
                            HourlyCharge = 100.00
                        },
                        new EmployeeType
                        {
                            Type = "Production Manager",
                            HourlyCharge = 150.00
                        },
                        new EmployeeType
                        {
                            Type = "Sales Associate",
                            HourlyCharge = 85.00
                        },
                        new EmployeeType
                        {
                            Type = "Sales and Finance Manager",
                            HourlyCharge = 75.00
                        });
                    context.SaveChanges();
                }
                */

                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                        new Project
                        {
                            Name = "LS Mall",
                            Desc = "Main Entrance",
                            EstCost = 7651.50,
                            BidDate = new DateTime(2019, 10, 10),
                            EstStartDate = new DateTime(2011, 06, 15),
                            EstFinishDate = new DateTime(2011, 06, 30),
                            StartDate = new DateTime(2011, 06, 14),
                            FinishDate = new DateTime(2011, 06, 18),
                            Cost = 5143.00,
                            BidCustApproved = true,
                            BidManagementApproved = true,
                            ClientID = context.Clients.FirstOrDefault(c => c.Name == "LS Mall" && c.Province == "Ontario").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Tamara" && d.LastName == "Bakken").Id
                        },
                        new Project
                        {
                            Name = "Papadimitriou Inc",
                            Desc = "HeadQuarters",
                            EstCost = 10.00,
                            BidDate = new DateTime(2019, 10, 10),
                            EstStartDate = new DateTime(2019, 10, 10),
                            EstFinishDate = new DateTime(2019, 10, 10),
                            StartDate = new DateTime(2019, 10, 10),
                            FinishDate = new DateTime(2019, 10, 10),
                            Cost = 10.00,
                            BidCustApproved = true,
                            BidManagementApproved = true,
                            ClientID = context.Clients.FirstOrDefault(c => c.Name == "Papadimitriou Inc" && c.Province == "Ontario").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Cheryl" && d.LastName == "Poy").Id

                        },
                        new Project
                        {
                            Name = "Test Bid",
                            Desc = "HeadQuarters",
                            EstCost = 10.00,
                            BidDate = new DateTime(2019, 10, 10),
                            EstStartDate = new DateTime(2019, 10, 10),
                            EstFinishDate = new DateTime(2019, 10, 10),
                            StartDate = new DateTime(2019, 10, 10),
                            FinishDate = new DateTime(2019, 10, 10),
                            Cost = 10.00,
                            BidCustApproved = true,
                            BidManagementApproved = false,
                            ClientID = context.Clients.FirstOrDefault(c => c.Name == "Master Contender Enterprise" && c.Province == "Ontario").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Cheryl" && d.LastName == "Poy").Id

                        },
                        new Project
                        {
                            Name = "Test Bid 2",
                            Desc = "HeadQuarters",
                            EstCost = 10.00,
                            BidDate = new DateTime(2019, 10, 10),
                            EstStartDate = new DateTime(2019, 10, 10),
                            EstFinishDate = new DateTime(2019, 10, 10),
                            StartDate = new DateTime(2019, 10, 10),
                            FinishDate = new DateTime(2019, 10, 10),
                            Cost = 10.00,
                            BidCustApproved = false,
                            BidManagementApproved = true,
                            ClientID = context.Clients.FirstOrDefault(c => c.Name == "Fake Inc" && c.Province == "Ontario").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Cheryl" && d.LastName == "Poy").Id

                        });
                    context.SaveChanges();
                }

                if (!context.ProjectEmployees.Any())
                {
                    context.ProjectEmployees.AddRange(
                        new ProjectEmployee
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            EmployeeID = context.Employees.FirstOrDefault(e => e.FirstName == "Bob" && e.LastName == "Reinhardt").Id
                        },
                        new ProjectEmployee
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            EmployeeID = context.Employees.FirstOrDefault(e => e.FirstName == "Sue" && e.LastName == "Kaufman").Id
                        },
                        new ProjectEmployee
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            EmployeeID = context.Employees.FirstOrDefault(e => e.FirstName == "Monica" && e.LastName == "Goce").Id
                        },
                        new ProjectEmployee
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            EmployeeID = context.Employees.FirstOrDefault(e => e.FirstName == "Bert" && e.LastName == "Swenson").Id
                        });
                    context.SaveChanges();
                }

                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(
                        new Models.Task
                        {
                            Desc = "Bid Process"
                        },
                        new Models.Task
                        {
                            Desc = "Contour Surface"
                        },
                        new Models.Task
                        {
                            Desc = "Install Large Plants"
                        });
                    context.SaveChanges();
                }

                if (!context.Labours.Any())
                {
                    context.Labours.AddRange(
                        new Labour
                        {
                            EstHours = 12,
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            TaskID = context.Tasks.FirstOrDefault(t => t.Desc == "Bid Process").ID
                        },
                        new Labour
                        {
                            EstHours = 6,
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            TaskID = context.Tasks.FirstOrDefault(t => t.Desc == "Contour Surface").ID
                        },
                        new Labour
                        {
                            EstHours = 8,
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            TaskID = context.Tasks.FirstOrDefault(t => t.Desc == "Install Large Plants").ID
                        }
                        );
                    context.SaveChanges();
                }

                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(
                        new Material
                        {
                            Type = "Plant",
                            Desc = "lacco"
                        },
                        new Material
                        {
                            Type = "Plant",
                            Desc = "cary"
                        },
                        new Material
                        {
                            Type = "Plant",
                            Desc = "margi"
                        },
                        new Material
                        {
                            Type = "Pottery",
                            Desc = "GFN48"
                        },
                        new Material
                        {
                            Type = "Pottery",
                            Desc = "GP50"
                        }, new Material
                        {
                            Type = "Material",
                            Desc = "CBRK5"
                        },
                        new Material
                        {
                            Type = "Material",
                            Desc = "TSOIL"
                        });
                    context.SaveChanges();
                }

                if (!context.Inventories.Any())
                {
                    context.Inventories.AddRange(
                        new Inventory
                        {
                            AvgNetPrice = 450.00,
                            ListPrice = 749.00,
                            SizeValue = 15,
                            SizeUnit = "gal",
                            Quantity = 3,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Plant" && m.Desc == "lacco").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 140.00,
                            ListPrice = 233.00,
                            SizeValue = 7,
                            SizeUnit = "gal",
                            Quantity = 14,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Plant" && m.Desc == "cary").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 45.00,
                            ListPrice = 75.00,
                            SizeValue = 2,
                            SizeUnit = "gal",
                            Quantity = 16,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Plant" && m.Desc == "margi").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 457.50,
                            ListPrice = 750.00,
                            SizeValue = 48,
                            SizeUnit = "in",
                            Quantity = 1,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Pottery" && m.Desc == "GFN48").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 110.00,
                            ListPrice = 195.00,
                            SizeValue = 50,
                            SizeUnit = "gal",
                            Quantity = 5,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Pottery" && m.Desc == "GP50").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 7.50,
                            ListPrice = 15.95,
                            SizeValue = 0,
                            SizeUnit = "bag",
                            Quantity = 3,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Material" && m.Desc == "CBRK5").ID
                        },
                        new Inventory
                        {
                            AvgNetPrice = 12.50,
                            ListPrice = 20.00,
                            SizeValue = 0,
                            SizeUnit = "yard",
                            Quantity = 10,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Type == "Material" && m.Desc == "TSOIL").ID
                        });
                    context.SaveChanges();
                }

                if (!context.ProjectMaterials.Any())
                {
                    context.ProjectMaterials.AddRange(
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "lacco").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "cary").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "margi").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "GFN48").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "GP50").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "CBRK5").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        },
                        new ProjectMaterials
                        {
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "LS Mall").ID,
                            InventoryID = context.Inventories.FirstOrDefault(i => i.Material.Desc == "TSOIL").ID,
                            MatDelivery = new DateTime(2010, 10, 10),
                            MatInstall = new DateTime(2010, 10, 10),
                            MatEstQty = 10,
                            MatActQty = 10
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
