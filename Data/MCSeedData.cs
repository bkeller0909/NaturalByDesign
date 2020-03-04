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

                //PatientConditions
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            FirstName = "Cheryl",
                            LastName = "Poy"
                        },
                        new Employee
                        {
                            FirstName = "Keri",
                            LastName = "Yamaguchi"
                        },
                        new Employee
                        {
                            FirstName = "Tamara",
                            LastName = "Bakken"
                        },
                        new Employee
                        {
                            FirstName = "Bob",
                            LastName = "Reinhardt"
                        },
                        new Employee
                        {
                            FirstName = "Sue",
                            LastName = "Kaufman"
                        },
                        new Employee
                        {
                            FirstName = "Monica",
                            LastName = "Goce"
                        },
                        new Employee
                        {
                            FirstName = "Bert",
                            LastName = "Swenson"
                        },
                        new Employee
                        {
                            FirstName = "Stan",
                            LastName = "Fenton"
                        },
                        new Employee
                        {
                            FirstName = "Joe",
                            LastName = "Smith"
                        },
                        new Employee
                        {
                            FirstName = "Jerry",
                            LastName = "Jones"
                        });
                    context.SaveChanges();
                }

                //Conditions
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

                if (!context.Labours.Any())
                {
                    context.Labours.AddRange(
                        new Labour
                        {
                            StartDate = new DateTime(2020, 01, 01),
                            TimeSpent = new DateTime(2020, 01, 01),
                            EstStartDate = new DateTime(2020, 01, 01),
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "").ID
                        },
                        new Labour
                        {
                            StartDate = new DateTime(2020, 01, 01),
                            TimeSpent = new DateTime(2020, 01, 01),
                            EstStartDate = new DateTime(2020, 01, 01),
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "").ID
                        },
                        new Labour
                        {
                            StartDate = new DateTime(2020, 01, 01),
                            TimeSpent = new DateTime(2020, 01, 01),
                            EstStartDate = new DateTime(2020, 01, 01),
                            ProjectID = context.Projects.FirstOrDefault(p => p.Name == "").ID
                        });
                    context.SaveChanges();
                }

                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(
                        new Models.Task
                        {
                            Hours = 2,
                            Desc = "",
                            LabourID = context.Labours.FirstOrDefault().ID
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
