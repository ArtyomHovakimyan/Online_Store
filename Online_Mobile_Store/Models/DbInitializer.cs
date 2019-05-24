using Online_Mobile_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Mobile_Store.Models
{
    public static class DbInitializer
    {
        private static Dictionary<string, Company> companies;
        public static Dictionary<string, Company> Companies
        {
            get
            {
                if (companies == null)
                {
                    var cmpyList = new Company[]
                    {
                        new Company { CompanyName = "Samsung", Address="Address  change" },
                        new Company { CompanyName = "LG", Address="Change" }
                    };

                    companies = new Dictionary<string, Company>();

                    foreach (Company cmpy in cmpyList)
                    {
                        companies.Add(cmpy.CompanyName, cmpy);
                    }
                }

                return companies;
            }
        }
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }
            var phones = new Phone[]
            {
                new Phone
                    {
                        Title = "Galaxy S",
                        Price = 12.95M,
                        ShortDescription = " A beverage prepared from coffee beans",
                        Company = Companies["Samsung"],
                        ImageUrl = "iphone_3.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                    },
                    new Phone
                    {
                        Title = "Galaxy",
                        Price = 12.95M,
                        ShortDescription = "A very refreshing Russian beverage",
                        Company = Companies["Samsung"],
                        ImageUrl = "iphone_4.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                    },
                    new Phone
                    {
                        Title = "Note 9 ",
                        Price = 12.95M,
                        ShortDescription = "Naturally contained in fruit or vegetable tissue.",
                        Company = Companies["LG"],
                        ImageUrl = "iphone_1.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                    }
            };
            foreach (Phone item in phones)
            {
                context.Phones.Add(item);
            }
            var company = new Company[]
                    {
                        new Company { CompanyName = "Samsung", Address="Address  change" },
                        new Company { CompanyName = "LG", Address="Change" },
                        new Company { CompanyName = "Apple", Address="Change" },
                        new Company { CompanyName = "Sony", Address="Change" }
                    };

            foreach (Company c in company)
            {
                context.Companies.Add(c);
            }
        }
    }
}
