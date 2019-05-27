using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Mobile_Store.Data;
using Online_Mobile_Store.Models;

namespace Online_Mobile_Store.Controllers
{
    [Authorize]
    public class PhoneController : Controller
    {
        ApplicationDbContext _context;
        public PhoneController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Add(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return View();
        }
        //public IActionResult Index()
        //{
        //    ViewData["Title"] = "Show all phones";
        //    var phone = _context.Phones;
        //    return View(phone);
        //}
        [AllowAnonymous]
        public IActionResult List()
        {
            ViewData["Title"] = "Show all phones";
            var phone = _context.Phones;
            return View(phone);
        }
        public ActionResult Index()
        {
            ViewData["Title"] = "Show all phones";
            var phone = _context.Phones;
            return View(phone);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}