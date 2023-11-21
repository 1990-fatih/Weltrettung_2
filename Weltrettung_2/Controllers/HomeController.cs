using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weltrettung_2.Models;

namespace Weltrettung_2.Controllers
{
    public class WeltrettungController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeltrettungController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Startseite
        public IActionResult Index()
        {
            return View();
        }

        // Weltretter Form
        [HttpGet]
        public IActionResult WeltretterForm()
        {
            return View();
        }

        // Weltretter Form Post
        [HttpPost]
        public IActionResult WeltretterForm(Weltretter weltretter)
        {
            if (ModelState.IsValid)
            {
                _context.Weltretter.Add(weltretter);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Daten wurden erfolgreich gespeichert.";
                return RedirectToAction("Index");
            }
            return View(weltretter);
        }

        // Liste aller Weltretter
        public IActionResult WeltretterListe()
        {
            var weltretterListe = _context.Weltretter.ToList();
            return View(weltretterListe);
        }

        // CRUD für Aggressoren (Die Bösen)
        // ... (AggressorController oluşturulabilir)
    }
}