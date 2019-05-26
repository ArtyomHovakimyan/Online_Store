using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Mobile_Store.Data;
using Online_Mobile_Store.Models;
using Online_Mobile_Store.ViewModels;

namespace Online_Mobile_Store.Controllers
{
    public class HomeController : Controller
    {
        //List<Company> companies;
        //List<Phone> phones;
        //public HomeController()
        //{
        //    Company apple = new Company { CompanyId = 5, CompanyName = "Apple", Address = "USA" };
        //    Company microsoft = new Company { CompanyId = 6, CompanyName = "Microsoft", Address = "USA" };
        //    Company google = new Company { CompanyId = 7, CompanyName = "Google", Address = "USA" };
        //    companies = new List<Company> { apple, microsoft, google };

        //    phones = new List<Phone>
        //    {
        //        new Phone{CompanyId=5,Company=apple,Title="IPhone 6S",Price=50000},
        //        new Phone{CompanyId=6,Company=apple,Title="IPhone 5S",Price=40000},
        //        new Phone{CompanyId=7,Company=microsoft,Title="Lumia 550",Price=9000},
        //        new Phone{CompanyId=2,Company=google,Title="Nexus 5x",Price=30000},
        //    };
        //}
        //[Authorize]
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Phones";
            var phones = _context.Phones;
            return View(phones);
        }

        //public IActionResult Index(int? companyId)
        //{
        //    List<CompanyModel> compModels = companies
        //     .Select(c => new CompanyModel { Id = c.CompanyId, Name = c.CompanyName })
        //      .ToList();

        //    compModels.Insert(0, new CompanyModel { Id = 0, Name = "All" });
        //    IndexViewModel indexViewModel = new IndexViewModel { Companies = compModels, Phones = phones };
        //    if (companyId != null && companyId > 0)
        //        indexViewModel.Phones = phones.Where(p => p.Company.CompanyId == companyId);

        //    return View(indexViewModel);
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
