using CRMTask.Models;
using CRMTask.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRMTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _dbContext;

        public HomeController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = _dbContext.Contacts.OrderBy(c => c.Name);
            ViewBag.contacts = contacts;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(contact);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Contact? contact = _dbContext.Contacts.FirstOrDefault(c => c.Id == id);
            if(contact is null)
            {
                return NotFound();
            }
            else return Json(contact);
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Update(contact);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Contact? contact = _dbContext.Contacts.FirstOrDefault(c => c.Id == Id);
            if (contact is null)
            {
                return NotFound();
            }

            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}