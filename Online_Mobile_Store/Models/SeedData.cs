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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Phones.Any())
                {
                    return;   // DB has been seeded
                }
                var companies = new Company[]
                {
                    new Company
                    {
                        CompanyId=1,
                        CompanyName="Apple",
                        Address="random address1",

                    },
                     new Company
                    {
                         CompanyId=2,
                        CompanyName="Samsung",
                        Address="random address2",

                    },
                    new Company
                    {
                         CompanyId=3,
                        CompanyName="LG",
                        Address="random address3",

                    }

                };
                foreach (var item in companies)
                {
                    context.Companies.Add(item);
                }
                context.SaveChanges();

                var phones = new Phone[]
                {
                    new Phone
                    {
                        Title = "Galaxy S",
                        Company=companies[0],
                        Price = 12.95M,
                        ShortDescription = " change this text",
                        ImageUrl = "iphone_3.jpg",
                        
                    },
                    new Phone
                    {
                        Title = "Galaxy",
                        Company=companies[1],
                        Price = 12.95M,
                        ShortDescription = "change this text",
                        ImageUrl = "iphone_4.jpg",
                     
                    },
                    new Phone
                    {
                        Title = "Note 9 ",
                        Company=companies[2],
                        Price = 12.95M,
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
}
