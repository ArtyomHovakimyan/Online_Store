using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult List()
        {
            ViewData["Title"] = "Show all phones";
            var phone = _context.Phones;
            return View(phone);
        }
        // GET: Phon
        public async Task<ActionResult> Index()
        {
            return View(await _context.Phones.Include(p=>p.Company).ToListAsync());
        }

        // GET: Phon/Details/5
        public ActionResult Details(int id)
        {
            var phone = _context.Phones.
                Include(p => p.Company)
                .AsNoTracking()
                .FirstOrDefault(m => m.PhoneId == id);
            if(phone==null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // GET: Phon/Create
        public ActionResult Create()
        {
            ViewData["CompanyName"] = new SelectList(_context.Companies, "CompanyName", "CompanyName");
            return View();
        }

        // POST: Phon/Create
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

        // GET: Phon/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CompanyName"] = new SelectList(_context.Companies, "CompanyName", "CompanyName");
            return View();
        }

        // POST: Phon/Edit/5
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

        // GET: Phon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Phon/Delete/5
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