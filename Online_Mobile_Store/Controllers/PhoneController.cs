using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Mobile_Store.Data;

namespace Online_Mobile_Store.Controllers
{
    public class PhoneController : Controller
    {
        ApplicationDbContext _context;
        public PhoneController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public void Add()
        {

        }
        public IActionResult List()
        {
            ViewData["Title"] = "Show all phones";
            var phone = _context.Phones;
            return View(phone);
        }
    }
}