using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_Mobile_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Mobile_Store.Models
{
    public static class SeedData
    {
        private static Dictionary<string, Company> companies;
        public static Dictionary<string, Company> Companies
        {
            get
            {
                if (companies == null)
                {
                    var compList = new Company[]
                    {
                        new Company { CompanyName = "Apple", Address="Random" },
                        new Company { CompanyName = "HTC", Address="Change" }
                    };

                    companies = new Dictionary<string, Company>();

                    foreach (Company item in compList)
                    {
                        companies.Add(item.CompanyName, item);
                    }
                }

                return companies;
            }
        }
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            

                if (context.Phones.Any())
                {
                    return;   // DB has been seeded
                }
                var phones = new Phone[]
                {
                    new Phone
                    {
                        Title = "Galaxy S",
                        Company=Companies["Apple"],
                        Price = 52000,
                        ShortDescription = " change this text",
                        ImageUrl = "iphone_3.jpg",
                        
                    },
                    new Phone
                    {
                        Title = "Galaxy",
                        Company=Companies["Apple"],
                        Price = 66000,
                        ShortDescription = "change this text",
                        ImageUrl = "iphone_4.jpg",
                     
                    },
                    new Phone
                    {
                        Title = "Note 9 ",
                        Company=Companies["HTC"],
                        Price = 39000,
                        ShortDescription = "change this text.",
                        ImageUrl = "iphone_1.jpg",
                       
                    }
                };
                foreach (var p in phones)
                {
                    context.Phones.Add(p);
                }
                context.SaveChanges();
            
        }
    }
}
